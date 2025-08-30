using System;
using Game.ECS.Data;
using Game.ECS.Data.Damage;
using Game.ECS.Data.Move;
using Game.ECS.Data.Projectile;
using Game.Utility;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

namespace Game.ECS.Systems
{
    [BurstCompile]
    public partial struct TowerAttackSystem : ISystem
    {
        
        private EntityQuery _entityQuery;
        
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();

            _entityQuery = SystemAPI.QueryBuilder()
                .WithAll<TowerData>()
                .Build();
            
            state.RequireForUpdate(_entityQuery);
        }
        
        public void OnUpdate(ref SystemState state)
        {
            var ecb = GetECB(ref state);
            float deltaTime = SystemAPI.Time.DeltaTime;
            
            foreach (var (towerData , attackCooldown,towerTransform, entity) 
                     in SystemAPI.Query<RefRO<TowerData>, RefRW<AttackCooldownData>, RefRO<LocalTransform>>().WithEntityAccess())
            {
                attackCooldown.ValueRW.Value -= attackCooldown.ValueRO.Multiplier * deltaTime;
                if (attackCooldown.ValueRO.Value > 0)
                {
                    continue;
                }
                
                float3 towerPos = towerTransform.ValueRO.Position;
                
                Entity target = Entity.Null;
                float closestDistance = float.MaxValue;
                float3 targetpos = float3.zero;

                foreach (var (targetTransform, enemyData, targetEntity) in SystemAPI.Query<RefRO<LocalTransform>, RefRO<EnemyTag>>().WithEntityAccess())
                {
                    float distance = math.distancesq(towerPos, targetTransform.ValueRO.Position);
                    if (distance < closestDistance && towerData.ValueRO.Range > distance)
                    {
                        closestDistance = distance;
                        target = targetEntity;
                        targetpos =  targetTransform.ValueRO.Position;
                    }
                }
                
                if (target != Entity.Null)
                {
                    attackCooldown.ValueRW.Value = towerData.ValueRO.AttackTime;
                    var projectileEntity = ecb.Instantiate(towerData.ValueRO.ProjectilePrefab);
                    ecb.SetComponent(projectileEntity, LocalTransform.FromPositionRotationScale(towerPos, quaternion.identity, .3f));
                    ecb.SetComponent(projectileEntity, new DamageData()
                    {
                        Value = towerData.ValueRO.Damage
                    });
                    ecb.AddComponent(projectileEntity, new ProjectileTargetData()
                    {
                        Target = target,
                        LastTargetPosition = targetpos
                    });

                    
                }
            }
        }
        
        
        private EntityCommandBuffer GetECB(ref SystemState state)
        {
            var ecbSingleton = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            return ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
        }
    }
}
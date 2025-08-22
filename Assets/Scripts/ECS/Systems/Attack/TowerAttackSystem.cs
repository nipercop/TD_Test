using Game.ECS.Data;
using Game.ECS.Data.Damage;
using Game.ECS.Data.Move;
using Game.ECS.Data.Projectile;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Systems
{
    [BurstCompile]
    public partial struct TowerAttackSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            float deltaTime = SystemAPI.Time.DeltaTime;
            foreach (var (towerData , attackCooldown,towerTransform, entity) 
                     in SystemAPI.Query<RefRO<TowerData>, RefRW<AttackCooldownData>, RefRO<LocalTransform>>().WithEntityAccess())
            {
                attackCooldown.ValueRW.Value -= attackCooldown.ValueRO.Speed * deltaTime;
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
            ecb.Playback(state.EntityManager);
        }
    }
}
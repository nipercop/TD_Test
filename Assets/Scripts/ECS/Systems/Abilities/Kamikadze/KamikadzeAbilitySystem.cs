using Game.ECS.Data;
using Game.ECS.Data.Ability;
using Game.ECS.Data.Health;
using Game.ECS.Systems.Abilities.Requests;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Systems
{
    [BurstCompile]
    public partial struct KamikadzeAbilitySystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var (request, reqEntity)
                     in SystemAPI.Query<RefRO<KamikadzeAbilityRequest>>().WithEntityAccess())
            {
                int damage = request.ValueRO.Damage;
                float radius = math.pow(2, request.ValueRO.Radius);
                foreach (var (towerData, towerTransform, entityTower) in SystemAPI.Query<RefRO<TowerData>, RefRO<LocalTransform>>().WithEntityAccess())
                {
                    float3 towerPosition = towerTransform.ValueRO.Position;
                    foreach (var (enemyHealth, enemyTranform) in SystemAPI.Query<RefRW<HealthData>, RefRO<LocalTransform>>().WithAll<EnemyTag>())
                    {
                        float distance = math.lengthsq(towerPosition - enemyTranform.ValueRO.Position);
                        if (distance < radius)
                        {
                            enemyHealth.ValueRW.Value -= damage;
                        }
                    }
                    ecb.DestroyEntity(entityTower);
                }
                ecb.DestroyEntity(reqEntity);
            }

            ecb.Playback(state.EntityManager);
        }
    }
}
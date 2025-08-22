using Game.ECS.Data;
using Game.ECS.Data.Damage;
using Game.ECS.Data.Health;
using Game.ECS.Data.Move;
using Game.ECS.Data.Projectile;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
namespace Game.ECS.Systems
{
    [BurstCompile]
    public partial struct ProjectileMoveSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
            
            foreach (var (projectileData, moveSpeed, 
                         transform , damage, entity) 
                     in SystemAPI.Query<RefRW<ProjectileTargetData>,RefRW<MoveSpeedData>,
                         RefRW<LocalTransform>, RefRO<DamageData>>().WithEntityAccess())
            {
                
                var targetEntity = projectileData.ValueRO.Target;
                var targetPosition = projectileData.ValueRO.LastTargetPosition;
                
                if (SystemAPI.Exists(targetEntity))
                {
                    targetPosition = SystemAPI.GetComponent<LocalTransform>(targetEntity).Position;
                    projectileData.ValueRW.LastTargetPosition = targetPosition;
                }
                
                float3 direction = targetPosition - transform.ValueRO.Position;
                float distance = math.length(direction);
                transform.ValueRW.Position += (direction / distance) * moveSpeed.ValueRO.Value * deltaTime;
                    
                if (distance < .3f)
                {
                    if (SystemAPI.Exists(targetEntity))
                    {
                        var targetHealth = SystemAPI.GetComponentRW<HealthData>(targetEntity);
                        targetHealth.ValueRW.Value -= damage.ValueRO.Value;
                    }
                    ecb.DestroyEntity(entity);
                }
            }
            ecb.Playback(state.EntityManager);
        }
    }
}

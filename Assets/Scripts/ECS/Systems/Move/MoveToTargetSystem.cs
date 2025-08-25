using Game.ECS.Aspects;
using Game.ECS.Data;
using Game.ECS.Data.Damage;
using Game.ECS.Data.Health;
using Game.ECS.Data.Move;
using Game.ECS.Data.Spawn;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Systems.Move
{
    [BurstCompile]
    public partial struct MoveToTargetSystem : ISystem
    {

        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
            
            foreach (var (enemyAspect, entity)
                     in SystemAPI.Query<EnemyAspect>().WithEntityAccess().WithAll<EnemyTag>())
            {
                var targetEntity = enemyAspect.Target;
                if (SystemAPI.Exists(targetEntity))
                {
                    var targetTransform = SystemAPI.GetComponent<LocalTransform>(targetEntity);
                    float3 direction = targetTransform.Position - enemyAspect.TransformData.ValueRO.Position;
                    float distance = math.length(direction);
                    enemyAspect.TransformData.ValueRW.Position += (direction / distance) * enemyAspect.MoveSpeed *enemyAspect.MoveSpeedMultiplier * deltaTime;
                    
                    if (distance < 1f)
                    {
                        var targetHealth = SystemAPI.GetComponentRW<HealthData>(targetEntity);
                        targetHealth.ValueRW.Value -= enemyAspect.Damage;
                        ecb.DestroyEntity(entity);
                    }
                }
            }
            ecb.Playback(state.EntityManager);
        }
    }

}
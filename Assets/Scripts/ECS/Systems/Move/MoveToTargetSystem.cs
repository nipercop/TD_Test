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
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();
        }

        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecb = GetECB(ref state);
            foreach (var (enemyAspect, entity)in SystemAPI.Query<EnemyAspect>().WithEntityAccess().WithAll<EnemyTag>())
            {
                var path = enemyAspect.Path;
                int waypointIndex = enemyAspect.WaypointIndex;
                float3 currentPosition = enemyAspect.Position;
                float3 targetPosition;
                if (waypointIndex < path.Value.Waypoints.Length)
                {
                    targetPosition = path.Value.Waypoints[waypointIndex];
                }
                else
                {
                    targetPosition = SystemAPI.Exists(enemyAspect.Target)
                        ? SystemAPI.GetComponent<LocalTransform>(enemyAspect.Target).Position
                        : currentPosition;
                }
            
                float3 direction = targetPosition - currentPosition;
                float distance =  math.length(direction);
                if (distance > 0)
                {
                    enemyAspect.TransformData.ValueRW.Position += 
                        (direction / distance) * enemyAspect.MoveSpeed * enemyAspect.MoveSpeedMultiplier * deltaTime;
                }
            
                if (distance < .1f)
                {
                    if (waypointIndex < path.Value.Waypoints.Length)
                    {
                        enemyAspect.IncreateWaypointIndex();
                    }
                    else
                    {
                        if (SystemAPI.Exists(enemyAspect.Target))
                        {
                            var targetHealth = SystemAPI.GetComponentRW<HealthData>(enemyAspect.Target);
                            targetHealth.ValueRW.Value -= enemyAspect.Damage;
                            ecb.DestroyEntity(entity);
                        }
                    }
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
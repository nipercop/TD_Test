using Game.ECS.Data.Damage;
using Game.ECS.Data.Health;
using Game.ECS.Data.Move;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Systems
{
    [BurstCompile]
    public partial struct MoveToTargetSystem : ISystem
    {

        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
            
            foreach (var (target,moveSpeed, transform , damage, entity) 
                     in SystemAPI.Query<RefRO<MoveToTargetData>,RefRW<MoveSpeedData>, RefRW<LocalTransform>, RefRO<DamageData>>().WithEntityAccess())
            {
                var targetTransform = SystemAPI.GetComponent<LocalTransform>(target.ValueRO.Target);
                float3 direction = targetTransform.Position - transform.ValueRO.Position;
                float distance = math.length(direction);
                transform.ValueRW.Position += (direction / distance) * moveSpeed.ValueRO.Value * deltaTime;
                
                if (distance < 1f)
                {
                    var targetHealth = SystemAPI.GetComponentRW<HealthData>(target.ValueRO.Target);
                    targetHealth.ValueRW.Value -= damage.ValueRO.Value;
                    ecb.DestroyEntity(entity);
                }
            }
            ecb.Playback(state.EntityManager);
        }
    }

}
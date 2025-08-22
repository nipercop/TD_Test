using Unity.Burst;
using Unity.Entities;
using Game.ECS.Data.Health;
using Unity.Collections;

namespace Game.ECS.Systems.Destroy
{
    [BurstCompile]
    public partial struct DestroyByLowHealthSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var (health, entity) in SystemAPI.Query<RefRO<HealthData>>().WithEntityAccess())
            {
                if (health.ValueRO.Value <= 0)
                {
                    ecb.DestroyEntity(entity);
                }
            }
            ecb.Playback(state.EntityManager);
        }
    }
}
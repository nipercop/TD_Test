using Unity.Burst;
using Unity.Entities;
using Game.ECS.Data.Health;
using Unity.Collections;

namespace Game.ECS.Systems.Destroy
{
    [BurstCompile]
    public partial struct DestroyByLowHealthSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EndSimulationEntityCommandBufferSystem.Singleton>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecb = GetECB(ref state);
            foreach (var (health, entity) in SystemAPI.Query<RefRO<HealthData>>().WithEntityAccess())
            {
                if (health.ValueRO.Value <= 0)
                {
                    ecb.DestroyEntity(entity);
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
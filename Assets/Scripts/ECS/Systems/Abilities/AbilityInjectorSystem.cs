using ECS.Systems.Abilities;
using Game.ECS.Data.Abilities.Requests;
using Game.ECS.Data.Abilities.Tags;
using Game.ECS.Data.Health;
using Unity.Burst;
using Unity.Entities;

namespace Game.ECS.Systems.Abilities.Injector
{
    [BurstCompile]
    public partial struct AbilityInjectorSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<AbilityRequest>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            foreach (var (request, reqEntity)
                     in SystemAPI.Query<RefRO<AbilityRequest>>().WithEntityAccess())
            {
                var buffer =  SystemAPI.GetBuffer<AbilityElementData>(reqEntity);
                foreach (var (healthData, entity)
                         in SystemAPI.Query<RefRO<HealthData>>().WithAll<AbilityTag>().WithEntityAccess())
                {
                    var buffer2 = SystemAPI.GetBuffer<AbilityElementData>(entity);
                    for (int i = 0; i < buffer.Length; i++)
                    {
                        buffer2.Add(buffer[i]);
                    }
                }
                ecb.DestroyEntity(reqEntity);
            }
            ecb.Playback(state.EntityManager);
        }
    }
}
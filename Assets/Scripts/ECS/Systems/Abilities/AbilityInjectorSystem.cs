using ECS.Systems.Abilities;
using ECS.Systems.Abilities.Enums;
using Game.ECS.Data;
using Game.ECS.Data.Ability;
using Game.ECS.Data.Abilities.Requests;
using Unity.Burst;
using Unity.Entities;

namespace Game.ECS.Systems.Abilities.Injector
{
    public partial struct AbilityInjectorSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<AbilityRequest>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            foreach (var (request, reqEntity)
                     in SystemAPI.Query<RefRO<AbilityRequest>>().WithEntityAccess())
            {
                foreach (var (tower, entity)
                         in SystemAPI.Query<RefRW<TowerData>>().WithEntityAccess())
                {
                    var buffer =  SystemAPI.GetBuffer<AbilityElementData>(reqEntity);
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
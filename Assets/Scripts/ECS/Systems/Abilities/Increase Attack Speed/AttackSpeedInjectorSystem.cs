using Game.ECS.Data;
using Game.ECS.Data.Ability;
using Game.ECS.Data.Abilities.Requests;
using Unity.Burst;
using Unity.Entities;

namespace Game.ECS.Systems.Abilities.Injector
{
    [BurstCompile]
    public partial struct AttackSpeedInjectorSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

            foreach (var (request, reqEntity) 
                     in SystemAPI.Query<RefRO<AttackSpeedAbilityRequest>>().WithEntityAccess())
            {
                foreach (var (tower, attackCoolDown, entity) 
                         in SystemAPI.Query<RefRW<TowerData>, RefRW<AttackCooldownData>>().WithEntityAccess())
                {
                    if (!state.EntityManager.HasComponent<AbilityLifeTimeData>(entity))
                    {
                        attackCoolDown.ValueRW.Speed = request.ValueRO.Multiplier;
                        ecb.AddComponent(entity, new AbilityLifeTimeData() { Value = request.ValueRO.Duration });
                    }
                }
                ecb.DestroyEntity(reqEntity);
            }
            ecb.Playback(state.EntityManager);
        }
    }

}
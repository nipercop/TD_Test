using Game.ECS.Data;
using Game.ECS.Data.Ability;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Systems
{ 
    [BurstCompile]
    public partial struct AbilityChangeStatsSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            foreach (var (abilityLifeTimeData, attackCooldown, entity) 
                     in SystemAPI.Query<RefRW<AbilityLifeTimeData>, RefRW<AttackCooldownData>>().WithEntityAccess())
            {
                abilityLifeTimeData.ValueRW.Value -= deltaTime;

                if (abilityLifeTimeData.ValueRO.Value <= 0)
                {
                    attackCooldown.ValueRW.Speed = 1;
                    ecb.RemoveComponent<AbilityLifeTimeData>(entity);
                }
            }
            ecb.Playback(state.EntityManager);
        }
    }
}
using ECS.Systems.Abilities;
using ECS.Systems.Abilities.Enums;
using Game.ECS.Data;
using Game.ECS.Data.Abilities.Tags;
using Game.ECS.Data.Ability;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Systems
{ 
    [BurstCompile]
    public partial struct AbilityAttackSpeedSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            float deltaTime = SystemAPI.Time.DeltaTime;
            foreach (var (cooldownData, entity) 
                     in SystemAPI.Query<RefRW<AttackCooldownData>>().WithEntityAccess().WithAll<AbilityTag>())
            {
                var buffer = SystemAPI.GetBuffer<AbilityElementData>(entity);
                for (int i = buffer.Length - 1; i >= 0; i--)
                {
                    var buff = buffer[i];
                    if (buff.Type == AbilityType.AttackSpeed)
                    {
                        cooldownData.ValueRW.Multiplier = buff.Value;
                        buff.Duration -= deltaTime;
                        if (buff.Duration <= 0)
                            buffer.RemoveAt(i);
                        else
                            buffer[i] = buff;
                    }
                }
            }
            
        }
    }
}
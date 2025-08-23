using ECS.Systems.Abilities;
using ECS.Systems.Abilities.Enums;
using Game.ECS.Data;
using Game.ECS.Data.Health;
using Game.ECS.Data.Abilities.Requests;
using Game.ECS.Data.Abilities.Tags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Systems.Abilities.Injector
{
    [BurstCompile]
    public partial struct KamikadzeAbilitySystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach (var (towerHealth, towerTransform, entity)
                     in SystemAPI.Query<RefRW<HealthData>, RefRO<LocalTransform>>()
                         .WithEntityAccess().WithAll<TowerData>())
            {
                var buffer = SystemAPI.GetBuffer<AbilityElementData>(entity);
                for (int i = buffer.Length - 1; i >= 0; i--)
                {
                    var buff = buffer[i];
                    if (buff.Type == AbilityType.Damage)
                    {
                        towerHealth.ValueRW.Value -= towerHealth.ValueRO.Value;
                        float3 towerPosition = towerTransform.ValueRO.Position;
                        buffer.RemoveAt(i);
                        foreach (var (enemyHealth, enemyTranform) 
                                 in SystemAPI.Query<RefRW<HealthData>, RefRO<LocalTransform>>().WithAll<EnemyTag>())
                        {
                            float distance = math.lengthsq(towerPosition - enemyTranform.ValueRO.Position);
                            if (distance < buff.Value)
                            {
                                enemyHealth.ValueRW.Value -= (int)buff.Duration;
                            }
                        }
                    }
                }
            }
        }
    }
}
using Game.ECS.Data;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Systems
{ 
    [BurstCompile]
    public partial struct AbilityChangeStatsSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {


            foreach (var var in SystemAPI.Query<RefRO<TowerData>>())
            {
                
            }
        }
    }
}
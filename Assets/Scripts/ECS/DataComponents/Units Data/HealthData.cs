using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Data.Health
{
    public struct HealthData : IComponentData
    {
        public int Value;
    }
}
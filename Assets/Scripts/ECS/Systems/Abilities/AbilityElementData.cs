using Unity.Entities;
using ECS.Systems.Abilities.Enums;

namespace ECS.Systems.Abilities
{
    public struct AbilityElementData : IBufferElementData
    {
        public AbilityType Type;
        public float Value;
        public float Duration;
    }
}
using Unity.Entities;

namespace Game.ECS.Data.Abilities.Requests
{
    public struct AttackSpeedAbilityRequest : IComponentData
    {
        public float Duration;
        public float Multiplier;
    }
}
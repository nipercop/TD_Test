using Unity.Entities;

namespace Game.ECS.Systems.Abilities.Requests
{
    public struct AttackSpeedAbilityRequest : IComponentData
    {
        public float Duration;
        public float Multiplier;
    }
}
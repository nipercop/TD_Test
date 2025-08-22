using Unity.Entities;

namespace Game.ECS.Data.Ability
{
    public struct AbilitySlowMoveData : IComponentData
    {
        public Entity Target;
        public float SlowPower;
        public int CurrentStack;
        public int MaxStacks;
        public float TickRate;
        public float Timer;
    }
}
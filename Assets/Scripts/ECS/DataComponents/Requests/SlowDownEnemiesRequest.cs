using Unity.Entities;

namespace Game.ECS.Data.Abilities.Requests
{
    public struct SlowDownEnemiesRequest : IComponentData
    {
        public float Duration;
        public float MoveSpeedDecreaser;
        public float TickRate;
        public int MaxStacks;
    }
}
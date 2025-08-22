using Unity.Entities;
namespace Game.ECS.Data.Move
{
    public struct MoveToTargetData : IComponentData
    {
        public Entity Target;
    }
}
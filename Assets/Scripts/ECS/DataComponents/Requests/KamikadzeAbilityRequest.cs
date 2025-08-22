using Unity.Entities;
namespace Game.ECS.Systems.Abilities.Requests
{
    public struct KamikadzeAbilityRequest : IComponentData
    {
        public float Radius;
        public int Damage;
    }
}
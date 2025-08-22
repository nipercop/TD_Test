using Unity.Entities;
namespace Game.ECS.Data.Abilities.Requests
{
    public struct KamikadzeAbilityRequest : IComponentData
    {
        public float Radius;
        public int Damage;
    }
}
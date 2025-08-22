using Unity.Entities;

namespace Game.ECS.Data
{
    public struct TowerData : IComponentData
    {
        public float Range;
        public float AttackTime;
        public int Damage;
        public Entity ProjectilePrefab;
    }
}
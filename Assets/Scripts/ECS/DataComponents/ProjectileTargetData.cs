using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Data.Projectile
{
    public struct ProjectileTargetData : IComponentData
    {
        public Entity Target;
        public float3 LastTargetPosition;
    }
}
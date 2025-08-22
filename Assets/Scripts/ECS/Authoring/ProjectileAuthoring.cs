using Game.ECS.Data;
using Game.ECS.Data.Damage;
using Game.ECS.Data.Move;
using Game.ECS.Data.Projectile;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Game.ECS.Authoring.Projectile
{
    public class ProjectileAuthoring : MonoBehaviour
    {
        public int Damage;
        public int MoveSpeed;
        private class Baker : Baker<ProjectileAuthoring>
        {
            public override void Bake(ProjectileAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new DamageData()
                {
                    Value = authoring.Damage
                });
                AddComponent(entity, new MoveSpeedData()
                {
                    Value = authoring.MoveSpeed
                });
            }
        }
    }
}
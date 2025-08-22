using Game.ECS.Data;
using Game.ECS.Data.Damage;
using Game.ECS.Data.Health;
using Game.ECS.Data.Move;
using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Authoring.Enemy
{
    public class EnemyAuthoring : MonoBehaviour
    {
        public int Health = 10;
        public int Damage = 10;
        public float MoveSpeed = 3f;
        
        private class Baker : Baker<EnemyAuthoring>
        {
            public override void Bake(EnemyAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.WorldSpace);
                AddComponent(entity, new EnemyTag());
                AddComponent(entity, new HealthData()
                {
                    Value = authoring.Health
                });
                AddComponent(entity, new MoveSpeedData()
                {
                    Value =  authoring.MoveSpeed
                });
                AddComponent(entity, new DamageData()
                {
                    Value = authoring.Damage
                });
                AddComponent(entity, new MoveToTargetData());
            }
        }
    }
}
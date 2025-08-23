using ECS.Systems.Abilities;
using Game.ECS.Data;
using Game.ECS.Data.Abilities.Tags;
using Game.ECS.Data.Health;
using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Authoring
{
    public class TowerAuthoring : MonoBehaviour
    {
        public float Range = 5;
        public float AttackTime = 1;
        public int Damage = 10;
        public GameObject ProjectilePrefab;

        private class Baker : Baker<TowerAuthoring>
        {
            public override void Bake(TowerAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new TowerData()
                {
                    Range = authoring.Range,
                    AttackTime = authoring.AttackTime,
                    Damage = authoring.Damage,
                    ProjectilePrefab = GetEntity( authoring.ProjectilePrefab , TransformUsageFlags.Dynamic)
                });
                AddComponent(entity, new AttackCooldownData
                {
                    Value = authoring.AttackTime,
                    Speed = 1
                });
                AddComponent(entity, new HealthData()
                {
                    Value =  50
                });
                AddComponent(entity, new AbilityTag());
                AddBuffer<AbilityElementData>(entity);
            }
        }
    }
}
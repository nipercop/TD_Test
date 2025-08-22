using Game.ECS.Data;
using Game.ECS.Data.Health;
using Unity.Entities;
using UnityEngine;

namespace Game.ECS.Authoring
{
    public class TownhallAuthoring : MonoBehaviour
    {
        public int Health = 100;
        
        private class Baker : Baker<TownhallAuthoring>
        {
            public override void Bake(TownhallAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new HealthData()
                {
                    Value = authoring.Health
                });
            }
        }
    }
}
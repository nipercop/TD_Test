using Game.ECS.Data;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.ECS.Authoring
{
    public class EnemySpawnPointAuthoring : MonoBehaviour
    {
        public float TimeToSpawn = 3;
        public int CountSpawn = 5;
        public GameObject EnemyPrefab;
        
        private class Baker : Baker<EnemySpawnPointAuthoring>
        {
            
            public override void Bake(EnemySpawnPointAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.WorldSpace);
                AddComponent(entity, new EnemySpawnData()
                {
                    CountToSpawn =  authoring.CountSpawn,
                    TimeToSpawn = authoring.TimeToSpawn,
                    Position = (float3)authoring.transform.position,
                    EnemyPrefab =  GetEntity(authoring.EnemyPrefab, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
}
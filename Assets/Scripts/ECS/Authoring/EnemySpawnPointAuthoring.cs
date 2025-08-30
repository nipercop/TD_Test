using Game.ECS.Data.Move;
using Game.ECS.Data.Spawn;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Game.ECS.Authoring.Spawn
{
    public class EnemySpawnPointAuthoring : MonoBehaviour
    {
        public float TimeToSpawn = 3;
        public int CountSpawn = 5;
        public GameObject EnemyPrefab;
        public GameObject Target;

        public Transform[] Waypoints;
        
        private class Baker : Baker<EnemySpawnPointAuthoring>
        {
            public override void Bake(EnemySpawnPointAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.WorldSpace);

                var builder = new BlobBuilder(Allocator.Temp);
                ref WaypointsData path = ref builder.ConstructRoot<WaypointsData>();
                var arrayBuilder = builder.Allocate(ref path.Waypoints, authoring.Waypoints.Length);
                for (int i = 0; i < authoring.Waypoints.Length; i++)
                {
                    arrayBuilder[i] = authoring.Waypoints[i].position;
                }
                var blobRef = builder.CreateBlobAssetReference<WaypointsData>(Allocator.Persistent);
                
                AddComponent(entity, new EnemySpawnData()
                {
                    CountToSpawn =  authoring.CountSpawn,
                    TimeToSpawn = authoring.TimeToSpawn,
                    Position = (float3)authoring.transform.position,
                    EnemyPrefab =  GetEntity(authoring.EnemyPrefab, TransformUsageFlags.Dynamic),
                    Target = GetEntity(authoring.Target, TransformUsageFlags.Dynamic),
                    StartSpawn = 1,
                    Path = blobRef
                });
            }
        }
    }
}
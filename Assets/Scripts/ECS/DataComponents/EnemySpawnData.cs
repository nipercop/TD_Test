using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Data
{
    public struct EnemySpawnData: IComponentData
    {
        public Entity EnemyPrefab;
        public int CountToSpawn;
        public float TimeToSpawn;
        public float3 Position;
    }
}
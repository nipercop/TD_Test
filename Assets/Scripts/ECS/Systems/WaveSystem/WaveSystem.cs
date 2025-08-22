using Game.ECS.Data;
using Game.ECS.Data.Move;
using Game.ECS.Data.Spawn;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Systems
{
    [BurstCompile]
    public partial struct WaveSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemySpawnData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var spawnData = SystemAPI.GetSingleton<EnemySpawnData>();
            if (spawnData.StartSpawn == 1)
            {
                return;
            }
            
            int aliveEnemies = 0;
            foreach (var enemy in SystemAPI.Query<EnemyTag>())
            {
                aliveEnemies++;
                break;
            }

            if (aliveEnemies == 0)
            {
                spawnData.CountToSpawn += 10;
                spawnData.StartSpawn = 1;
                SystemAPI.SetSingleton(spawnData);
            }
        }
    }
}
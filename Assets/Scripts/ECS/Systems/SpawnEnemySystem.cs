using Game.ECS.Data;
using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Game.ECS.Systems
{
    [BurstCompile]
    public partial struct SpawnEnemySystem : ISystem
    {
        private float _timer;
        
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemySpawnData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            var spawnData = SystemAPI.GetSingleton<EnemySpawnData>();
            
            _timer -= SystemAPI.Time.DeltaTime;
            if (_timer > 0)
            {
                return;
            }
            _timer = spawnData.TimeToSpawn;
            
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            for (int i = 0; i < spawnData.CountToSpawn; i++)
            {
                var enemy = ecb.Instantiate(spawnData.EnemyPrefab);
                float3 offset = new float3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f));
                ecb.SetComponent(enemy, LocalTransform.FromPosition(spawnData.Position + offset));
            }
            ecb.Playback(state.EntityManager);
        }
    }
}
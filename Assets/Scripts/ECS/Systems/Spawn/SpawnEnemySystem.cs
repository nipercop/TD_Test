using System;
using Game.ECS.Data.Move;
using Game.ECS.Data.Spawn;
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
        
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<EnemySpawnData>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var spawnData = SystemAPI.GetSingleton<EnemySpawnData>();

            if (spawnData.StartSpawn == 0)
            {
                return;
            }
            spawnData.StartSpawn = 0;
            SystemAPI.SetSingleton(spawnData);
            
            var ecb = new EntityCommandBuffer(Allocator.Temp);
            for (int i = 0; i < spawnData.CountToSpawn; i++)
            {
                var enemy = ecb.Instantiate(spawnData.EnemyPrefab);
                ecb.SetComponent(enemy, new MoveToTargetData()
                {
                    Target = spawnData.Target
                });
                float3 offset = new float3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f));
                ecb.SetComponent(enemy, LocalTransform.FromPosition(spawnData.Position + offset));
            }
            ecb.Playback(state.EntityManager);
        }
    }
}
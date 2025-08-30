using ECS.Systems.Abilities;
using Game.ECS.Data;
using Game.ECS.Data.Abilities.Tags;
using Game.ECS.Data.Health;
using Game.ECS.Data.Spawn;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

partial struct TowerSpawnSystem : ISystem
{
    
    private EntityQuery _entityQuery;
    
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<BeginInitializationEntityCommandBufferSystem.Singleton>();

        _entityQuery = SystemAPI.QueryBuilder()
            .WithAll<TowerSpawnData>().Build();
        
        state.RequireForUpdate(_entityQuery);
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecb = GetECB(ref state);
        foreach (var entity in _entityQuery.ToEntityArray(Allocator.Temp))
        {
            var spawnData = state.EntityManager.GetComponentData<TowerSpawnData>(entity);
            var tower= ecb.Instantiate(spawnData.TowerPrefab);

            ecb.SetComponent(tower, LocalTransform.FromPosition(spawnData.Position));
            ecb.AddComponent(tower, new TowerData()
            {
                Range = spawnData.Range,
                AttackTime = spawnData.AttackTime,
                Damage = spawnData.Damage,
                ProjectilePrefab = spawnData.ProjectilePrefab
            });
            ecb.AddComponent(tower, new AttackCooldownData
            {
                Value = spawnData.AttackTime,
                Multiplier = 1
            });
            ecb.AddComponent(tower, new HealthData()
            {
                Value =  spawnData.Health
            });
            ecb.AddComponent(tower, new AbilityTag());
            ecb.AddBuffer<AbilityElementData>(tower);
            
            ecb.DestroyEntity(entity);
            //ecb.RemoveComponent<TowerSpawnData>(entity);
        }
    }

    
    private EntityCommandBuffer GetECB(ref SystemState state)
    {
        var ecbSingleton = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
        return ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
    }
}

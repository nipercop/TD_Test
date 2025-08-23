using Game.ECS.Data;
using Game.ECS.Data.Ability;
using Game.ECS.Data.Abilities.Requests;
using Game.ECS.Data.Move;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Game.ECS.Systems
{
    namespace Game.ECS.Systems.Abilities.Injector
    {

        [BurstCompile]
        public partial struct AbilityMoveSpeedSystem : ISystem
        {

            // потом доделать
            
            // public void OnUpdate(ref SystemState state)
            // {
            //     var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);
            //     foreach (var (request, reqEntity) 
            //              in SystemAPI.Query<RefRO<SlowDownEnemiesRequest>>().WithEntityAccess())
            //     {
            //         foreach (var (moveData, enemyEntity) in
            //                  SystemAPI.Query<RefRW<MoveSpeedData>>().WithEntityAccess().WithAll<EnemyTag>())
            //         {
            //             
            //             // var newEntity = ecb.CreateEntity();
            //             // ecb.AddComponent(newEntity, new AbilityLifeTimeData
            //             // {
            //             //     Value = request.ValueRO.Duration
            //             // });
            //             // ecb.AddComponent(newEntity, new AbilitySlowMoveData()
            //             // {
            //             //     CurrentStack = 1,
            //             //     MaxStacks =  request.ValueRO.MaxStacks,
            //             //     SlowPower = request.ValueRO.MoveSpeedDecreaser,
            //             //     TickRate = request.ValueRO.TickRate,
            //             //     Timer = 0
            //             // });
            //             
            //             if (!state.EntityManager.HasComponent<AbilityLifeTimeData>(enemyEntity))
            //             {
            //                 ecb.AddComponent(enemyEntity, new AbilitySlowMoveData()
            //                 {
            //                     CurrentStack = 1,
            //                     MaxStacks =  request.ValueRO.MaxStacks,
            //                     SlowPower = request.ValueRO.MoveSpeedDecreaser,
            //                     TickRate = request.ValueRO.TickRate,
            //                     Timer = 0
            //                 });
            //                 ecb.AddComponent(enemyEntity, new AbilityLifeTimeData()
            //                 {
            //                     Value = request.ValueRO.Duration
            //                 });
            //             }
            //         }
            //         ecb.DestroyEntity(reqEntity);
            //     }
            //     
            //     ecb.Playback(state.EntityManager);
            // }
        }
    }
}
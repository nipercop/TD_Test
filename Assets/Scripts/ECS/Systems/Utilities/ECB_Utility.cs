using Unity.Entities;
using UnityEngine;

namespace Game.Utility
{
    public static class ECB_Utility
    {

        
        public static EntityCommandBuffer GetBeginSimulationECB(ref SystemState state)
        {
            var ecbSingleton = state.EntityManager
                .CreateEntityQuery(ComponentType.ReadOnly<BeginSimulationEntityCommandBufferSystem.Singleton>())
                .GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();

            return ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
        }
        
        
        public static EntityCommandBuffer GetEndSimulationECB(ref SystemState state)
        {
            var ecbSingleton = state.EntityManager
                .CreateEntityQuery(ComponentType.ReadOnly<EndSimulationEntityCommandBufferSystem.Singleton>())
                .GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();

            return ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
        }
        
        
        
        // public static EntityCommandBuffer EndSimulation(ref SystemState state)
        // {
        //     return GetCommandBuffer<EndSimulationEntityCommandBufferSystem>(ref state);
        // }
        
        
        // private static EntityCommandBuffer GetCommandBuffer<T>(ref SystemState state)
        //     where T :  EntityCommandBufferSystem
        // {
        //     var singleton = state.EntityManager
        //         .CreateEntityQuery(ComponentType.ReadOnly<T.Singleton>())
        //         .GetSingleton<T.Singleton>();
        //
        //     return singleton.CreateCommandBuffer(state.WorldUnmanaged);
        // }
    }
}
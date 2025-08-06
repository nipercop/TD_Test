using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateSpawnEnemies : GameStateMachineCore
    {
        public override GameState GameState { get; } = GameState.SpawnEnemies;
        
        public  GameStateSpawnEnemies(GamePlayStateSystem gamePlayStateSystem) : base(gamePlayStateSystem)
        {
            
        }
        
        
    }
}
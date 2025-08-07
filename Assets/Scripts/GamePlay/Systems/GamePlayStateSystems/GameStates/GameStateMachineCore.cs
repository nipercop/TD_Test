using Game.GamePlayCore.Systems.GamePlayState;
using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public enum GameState
    {
        Idle = 0,
        SpawnEnemies = 1,
        WaitForEndWave = 2,
        EndGame = 3,
    }
    
    public class GameStateMachineCore
    {
        protected readonly GamePlayStateSystem _gamePlayStateSystem;
        public virtual GameState GameState { get; }
        protected GameStateMachineCore(GamePlayStateSystem gamePlayStateSystem)
        {
            _gamePlayStateSystem = gamePlayStateSystem;
        }
        
        public virtual void Entry() { }

        public virtual void DoUpdate(float deltaTime) { }
        
        public virtual void Exit() { }

        
    }
}

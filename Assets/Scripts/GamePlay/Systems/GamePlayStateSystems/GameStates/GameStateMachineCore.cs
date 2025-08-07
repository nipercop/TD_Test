using Game.GamePlayCore.Systems.GamePlayState;
using UnityEngine;
using VContainer;

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
        [Inject] protected readonly GamePlayStateSystem _gamePlayStateSystem;
        public virtual GameState GameState { get; }
        public virtual void Entry() { }
        public virtual void DoUpdate(float deltaTime) { }
        public virtual void Exit() { }
        
    }
}

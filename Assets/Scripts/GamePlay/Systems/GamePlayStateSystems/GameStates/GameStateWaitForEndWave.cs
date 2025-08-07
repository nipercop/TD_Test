using Game.GamePlayCore.Systems.GamePlayState;
using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateWaitForEndWave : GameStateMachineCore
    {
        public  GameStateWaitForEndWave(GamePlayStateSystem gamePlayStateSystem) : base(gamePlayStateSystem) { }
        
        public override GameState GameState { get; } = GameState.WaitForEndWave;

        public override void DoUpdate(float deltaTime)
        {
            
        }
    }
}
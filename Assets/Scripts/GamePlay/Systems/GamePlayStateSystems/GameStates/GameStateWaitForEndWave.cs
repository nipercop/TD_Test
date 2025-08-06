using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateWaitForEndWave : GameStateMachineCore
    {
        public override GameState GameState { get; } = GameState.WaitForEndWave;
        
        public  GameStateWaitForEndWave(GamePlayStateSystem gamePlayStateSystem) : base(gamePlayStateSystem)
        {
            
        }
        
        
    }
}
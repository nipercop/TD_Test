using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateIdle : GameStateMachineCore
    {
        public override GameState GameState { get; } = GameState.Idle;
        
        public GameStateIdle(GamePlayStateSystem gamePlayStateSystem) : base(gamePlayStateSystem)
        {
            
        }
        
        
    }
}

using Game.GamePlayCore.Systems.GamePlayState;
using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateEndGame : GameStateMachineCore
    {
        public override GameState GameState { get; } = GameState.EndGame;

        public override void Entry()
        {
            _gamePlayStateSystem.EndGame();
        }
    }
}

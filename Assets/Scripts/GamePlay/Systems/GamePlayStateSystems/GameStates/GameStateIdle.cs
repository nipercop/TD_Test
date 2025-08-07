using Game.GamePlayCore.Systems.GamePlayState;
using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateIdle : GameStateMachineCore
    {
        public GameStateIdle(GamePlayStateSystem gamePlayStateSystem) : base(gamePlayStateSystem) { }
        
        public override GameState GameState { get; } = GameState.Idle;
        private float _timer;

        public override void Entry()
        {
            _timer = 3f;
        }

        public override void DoUpdate(float deltaTime)
        {
            _timer -= deltaTime;
            if (_timer <= 0)
            {
                _gamePlayStateSystem.ChangeState(GameState.SpawnEnemies);
            }
        }
    }
}

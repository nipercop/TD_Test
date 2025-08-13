using Game.GamePlayCore.Systems.GamePlayState;
using Game.GamePlayCore.Systems.Units;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateWaitForEndWave : GameStateMachineCore
    {
        [Inject] private readonly UnitsSystem _unitsSystem;
        public override GameState GameState { get; } = GameState.WaitForEndWave;

        public override void DoUpdate(float deltaTime)
        {
            if (_unitsSystem.EnemyUnits.Count == 0)
            {
                _gamePlayStateSystem.ChangeState(GameState.Idle);
            }
        }
    }
}
using Game.GamePlayCore.Systems.GamePlayState;
using UnityEngine;

namespace Game.GamePlayCore.Systems.StateMachine
{
    public class GameStateSpawnEnemies : GameStateMachineCore
    {
        public override GameState GameState { get; } = GameState.SpawnEnemies;
        private float _delaySpawn;

        public override void Entry()
        {
            _delaySpawn = .1f;
        }

        public override void DoUpdate(float deltaTime)
        {
            _delaySpawn -= deltaTime;
            if (_delaySpawn <= 0f)
            {
                _delaySpawn = .1f;
                _gamePlayStateSystem.SpawnEnemies();
            }
        }
    }
}
using System;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Systems;
using Game.GamePlayCore.Interfaces.Systems.Spawners;
using Game.GamePlayCore.Systems.StateMachine;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Systems
{
    public class GamePlayStateSystem : MonoBehaviour, IUpdatable
    {
        [Inject] private IGamePlayUpdater _updater;
        [Inject] private ISpawnerSystem _enemySpawnerSystem;

        [SerializeField] private float _timer = 0;

        private GameStateMachineCore[] _states ;
        private GameStateMachineCore _currentGameState;
        
        
        private void Start()
        {
            _states = new GameStateMachineCore[]
            {
                new GameStateIdle(this),
                new GameStateSpawnEnemies(this),
                new GameStateWaitForEndWave(this)
            };
            _currentGameState = _states[0];
            
            _updater.AddUpdatable(this);
        }

        private void OnDestroy()
        {
            _updater.RemoveUpdatable(this);
        }

        public void DoUpdate(float deltaTime)
        {
            _currentGameState.DoUpdate(deltaTime);
        }

        public void ChangeState(GameState newState)
        {
            var state = GetStateMachine(newState);
            if (state == null)
            {
                Debug.LogError("State not found: "+ newState);
                return;
            }
            _currentGameState.Exit();
            _currentGameState = state;
            _currentGameState.Entry();
            
        }

        private GameStateMachineCore GetStateMachine(GameState newState)
        {
            foreach (var state in _states)
            {
                if(state.GameState == newState)
                    return state;
            }
            return null;
        }
    }
}

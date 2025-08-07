using System;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Systems;
using Game.GamePlayCore.Interfaces.Systems.Spawners;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Systems.StateMachine;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Systems.GamePlayState
{
    public class GamePlayStateSystem : MonoBehaviour, IUpdatable
    {
        [Inject] private IGamePlayUpdater _updater;
        [Inject] private ISpawnerSystem _enemySpawnerSystem;
        [Inject] private IObjectResolver _resolver;
        //[SerializeField] private float _timer = 0;

        private GameStateMachineCore[] _states ;
        private GameStateMachineCore _currentGameState;
        private SpawnData _spawnData = new ();
        
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _destinationPoint;
        [SerializeField] private int _currentWave = 0;
        [SerializeField] private WaveData[] _waveDatas;
        
        private void Start()
        {
            _states = new GameStateMachineCore[]
            {
                new GameStateIdle(this),
                new GameStateSpawnEnemies(this),
                CreateWithInject(new GameStateWaitForEndWave(this)),
                new GameStateEndGame(this)
            };
            _currentGameState = _states[0];
            
            SetSpawnData();
            
            _updater.AddUpdatable(this);
        }
        
        private T CreateWithInject<T>(T instance)
        {
            _resolver.Inject(instance);
            return instance;
        }

        private void SetSpawnData()
        {
            _spawnData.CountSpawn = _waveDatas[_currentWave].Count;
            _spawnData.Prefab = _waveDatas[_currentWave].PrefabEnemy;
            _spawnData.NewStats  = _waveDatas[_currentWave].Stats;
            _spawnData.Position = _spawnPoint.position;
            _spawnData.Destination = _destinationPoint.position;
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


        public void SpawnEnemies()
        {
            SetSpawnData();
            _enemySpawnerSystem.Spawn(_spawnData);
            _currentWave++;
            if (_currentWave >= _waveDatas.Length)
            {
                ChangeState(GameState.EndGame);
            }
            else
            {
                ChangeState(GameState.WaitForEndWave);
            }
        }
    }
}

using System;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Systems;
using Game.GamePlayCore.Interfaces.Systems.Spawners;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Systems
{
    public class GamePlayStateSystem : MonoBehaviour, IUpdatable
    {
        [Inject] private IGamePlayUpdater _updater;
        [Inject] private ISpawnerSystem _enemySpawnerSystem;

        [SerializeField] private float _timer = 0;
        
        private void Start()
        {
            _updater.AddUpdatable(this);
        }

        private void OnDestroy()
        {
            _updater.RemoveUpdatable(this);
        }

        public void DoUpdate(float deltaTime)
        {
            
        }
    }
}

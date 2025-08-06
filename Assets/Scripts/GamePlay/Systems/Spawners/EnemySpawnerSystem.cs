using System;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Systems.Updater;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Systems.Spawners
{
    public class EnemySpawnerSystem : MonoBehaviour, IUpdatable
    {

        [Inject] private GamePlayUpdater _updater;

        void Start()
        {
            _updater.AddUpdatable(this);
        }

        private void OnDestroy()
        {
            _updater.RemoveUpdatable(this);
        }

        void Update()
        {
        
        }

        public void DoUpdate(float deltaTime)
        {
            
        }
    }
}

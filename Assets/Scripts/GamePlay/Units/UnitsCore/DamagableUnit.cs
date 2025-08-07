using System;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Systems;
using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Systems.Units;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Units
{
    public abstract class DamagableUnit : MonoBehaviour , IDamagable, IUpdatable
    {
        [SerializeField] protected StatsUnit _stats;
        
        [Inject] protected UnitsSystem _unitsSystem;
        [Inject] protected IGamePlayUpdater _gamePlayUpdater;
        
        public StatsUnit Stats => _stats;

        protected virtual void Start()
        {
            _gamePlayUpdater.AddUpdatable(this);
        }

        protected virtual void OnDestroy()
        {
            _gamePlayUpdater.RemoveUpdatable(this);
        }

        public virtual void TakeDamage(int damage)
        {
            _stats.Health -= damage;
            if (_stats.Health <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }

        public virtual void SetSpawnData(SpawnData spawnData)
        {
            _stats = spawnData.NewStats;
        }
        
        
        public virtual void DoUpdate(float deltaTime)
        {
        }
        
    }
}

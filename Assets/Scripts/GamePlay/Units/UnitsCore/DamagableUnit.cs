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
        public int Health;
        public StatsUnit Stats;
        [Inject] protected UnitsSystem _unitsSystem;
        [Inject] protected IGamePlayUpdater _gamePlayUpdater;
        
        protected virtual void Start() { }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
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
            Stats = spawnData.NewStats;
        }
        
        
        public virtual void DoUpdate(float deltaTime)
        {
        }
        
    }
}

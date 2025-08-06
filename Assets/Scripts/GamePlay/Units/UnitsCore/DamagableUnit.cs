using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Units;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Spawners.Data;
using UnityEngine;

namespace Game.GamePlayCore.Units
{
    public abstract class DamagableUnit : MonoBehaviour , IDamagable, IUpdatable
    {
        public int Health;
        public StatsUnit Stats;
        
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

using System.Collections.Generic;
using Game.GamePlayCore.Abilities;
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
        [SerializeField] protected int _faction;
        [Inject] protected UnitsSystem _unitsSystem;
        [Inject] protected IGamePlayUpdater _gamePlayUpdater;
        
        //private List<AbilityCore> _abilities = new List<AbilityCore>();
        
        public StatsUnit Stats => _stats;
        public int Faction => _faction;

        protected virtual void Start()
        {
            _unitsSystem.AddUnit(this);
            _gamePlayUpdater.AddUpdatable(this);
        }

        protected virtual void OnDestroy()
        {
            _gamePlayUpdater.RemoveUpdatable(this);
            _unitsSystem.RemoveUnit(this);
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
            // foreach (var ability in _abilities)
            // {
            //     ability.Deactivate();
            // }
            // _abilities.Clear();
            Destroy(gameObject);
        }

        public virtual void SetSpawnData(SpawnData spawnData)
        {
            _stats = spawnData.NewStats;
        }

        // public virtual void SetAbility(AbilityCore ability)
        // {
        //     _abilities.Add(ability);
        // }
        
        
        public virtual void DoUpdate(float deltaTime)
        {
        }
        
    }
}

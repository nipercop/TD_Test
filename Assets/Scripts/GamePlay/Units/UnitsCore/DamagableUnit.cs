using Game.Abstractions.Ability;
using Game.DataBase.Abilities.Logic;
using Game.DataBase.Units;
using Game.GamePlayCore.Interfaces;
using Game.GamePlayCore.Interfaces.Systems;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Spawners.Data;
using Game.GamePlayCore.Systems.Units;
using UnityEngine;
using VContainer;

namespace Game.GamePlayCore.Units
{
    public abstract class DamagableUnit : MonoBehaviour, IUpdatable, IAbilityTarget
    {
        [SerializeField] protected StatsUnit _stats;
        [SerializeField] protected int _faction;
        [Inject] protected UnitsSystem _unitsSystem;
        [Inject] protected IGamePlayUpdater _gamePlayUpdater;
        
        public IStatsUnit Stats
        {
            get => _stats;
            set => _stats = (StatsUnit)value;
        }

        public int Faction => _faction;
        public Vector3 Position => transform.position;

        protected virtual void Start()
        {
            _stats = new StatsUnit(_stats);
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
            _stats.Health -=  (int)(damage *  (1 - _stats.ReceiveDamageResistance));
            if (_stats.Health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            Destroy(gameObject);
        }

        public virtual void SetSpawnData(SpawnData spawnData)
        {
            _stats = new StatsUnit(spawnData.NewStats);
        }
        
        public virtual void DoUpdate(float deltaTime)
        {
        }
        
    }
}

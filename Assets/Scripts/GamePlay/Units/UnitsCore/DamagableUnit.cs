using Game.DataBase.Abilities.Logic;
using Game.DataBase.Units;
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
        
        public StatsUnit Stats => _stats;
        public int Faction => _faction;

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

        public void IncreaseStats(int id, params AbilityChangeStats[] statsToChange)
        {
            foreach (var stat in statsToChange)
            {
                var newStats = _stats;
                switch (stat.statType)
                { 
                    case StatsType.MoveSpeed:
                        newStats.MoveSpeed.AddChangeStat(id, stat);
                        break;
                    case StatsType.AttackSpeed:
                        newStats.AttackSpeed.AddChangeStat(id, stat);
                        break;
                }
                _stats = newStats;
            }
        }
        
        public void DecreaseStats(int id, params AbilityChangeStats[] statsToChange)
        {
            foreach (var stat in statsToChange)
            {
                var newStats = _stats;
                switch (stat.statType)
                { 
                    case StatsType.MoveSpeed:
                        newStats.MoveSpeed.RemoveChangeStat(id);
                        break;
                    case StatsType.AttackSpeed:
                        newStats.AttackSpeed.RemoveChangeStat(id);
                        break;
                }
                _stats = newStats;
            }
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

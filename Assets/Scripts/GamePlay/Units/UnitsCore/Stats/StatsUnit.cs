
using Game.Abstractions.Ability;
using UnityEngine;
using StatsType = Game.Abstractions.Ability.StatsType;

namespace Game.GamePlayCore.Stats
{
    [System.Serializable]
    public struct StatsUnit : IStatsUnit
    {
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private FloatValue _moveSpeed;
        [SerializeField] private FloatValue _attackSpeed;

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Damage  {
            get { return _damage; }
            set { _damage = value; }
        }
        public float MoveSpeed => _moveSpeed.Value;
        public float AttackSpeed => _attackSpeed.Value;

        public StatsUnit(StatsUnit other)
        {
            _health = other._health;
            _damage = other._damage;
            _moveSpeed = new FloatValue(other._moveSpeed);
            _attackSpeed = new FloatValue(other._attackSpeed);
        }
        
        public StatsUnit(int health, int damage, float moveSpeed, float attackSpeed)
        {
            _health = health;
            _damage = damage;
            _moveSpeed = new FloatValue(moveSpeed);
            _attackSpeed = new FloatValue(attackSpeed);
        }

        public void IncreaseValue(int id, IAbilityChangeStats stats)
        {
            switch (stats.StatType)
            {
                case StatsType.MoveSpeed:
                    _moveSpeed.AddChangeStat(id, stats.StatsChangeType, stats.Value);
                    break;
                case StatsType.AttackSpeed :
                    _attackSpeed.AddChangeStat(id, stats.StatsChangeType, stats.Value);
                    break;
            }
        }

        public void DecreaseValue(int id, IAbilityChangeStats stats)
        {
            switch (stats.StatType)
            {
                case StatsType.MoveSpeed:
                    _moveSpeed.RemoveChangeStat(id);
                    break;
                case StatsType.AttackSpeed :
                    _attackSpeed.RemoveChangeStat(id);
                    break;
            }
        }
       
    }
}

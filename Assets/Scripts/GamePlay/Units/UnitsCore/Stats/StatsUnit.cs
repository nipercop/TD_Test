
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
        [SerializeField] private FloatValue _receiveDamageResistance;

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
        public float ReceiveDamageResistance => _receiveDamageResistance.ValueClampedMinusToOne;

        public StatsUnit(StatsUnit other)
        {
            _health = other._health;
            _damage = other._damage;
            _moveSpeed = new FloatValue(other._moveSpeed);
            _attackSpeed = new FloatValue(other._attackSpeed);
            _receiveDamageResistance = new FloatValue(other._receiveDamageResistance);
        }

        public void IncreaseValue(int id, StatsType statType, StatsChangeType changeType, float value)
        {
            switch (statType)
            {
                case StatsType.MoveSpeed:
                    _moveSpeed.AddChangeStat(id, changeType, value);
                    break;
                case StatsType.AttackSpeed:
                    _attackSpeed.AddChangeStat(id, changeType,value);
                    break;
                case StatsType.DamageResistance:
                    _receiveDamageResistance.AddChangeStat(id, changeType, value);
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
                case StatsType.DamageResistance:
                    _receiveDamageResistance.RemoveChangeStat(id);
                    break;
            }
        }
       
    }
}


using Game.Abstractions.Ability;
using StatsType = Game.Abstractions.Ability.StatsType;

namespace Game.GamePlayCore.Stats
{
    [System.Serializable]
    public struct StatsUnit : IStatsUnit
    {
        public int Health;
        public int Damage;
        public FloatValue MoveSpeed;
        public FloatValue AttackSpeed;

        public int uHealth
        {
            get { return Health; }
            set { Health = value; }
        }

        public int uDamage  {
            get { return Damage; }
            set { Damage = value; }
        }
        
        IFloatValue IStatsUnit.uMoveSpeed
        {
            get => MoveSpeed;
            set => MoveSpeed = (FloatValue) value;
        }

        IFloatValue IStatsUnit.uAttackSpeed
        {
            get => AttackSpeed;
            set => AttackSpeed = (FloatValue)  value;
        }

        public StatsUnit(StatsUnit other)
        {
            Health = other.Health;
            Damage = other.Damage;
            MoveSpeed = new FloatValue(other.MoveSpeed.Value);
            AttackSpeed = new FloatValue(other.AttackSpeed.Value);
        }
        
        public StatsUnit(int health, int damage, float moveSpeed, float attackSpeed)
        {
            Health = health;
            Damage = damage;
            MoveSpeed = new FloatValue(moveSpeed);
            AttackSpeed = new FloatValue(attackSpeed);
        }

        public void IncreaseValue(int id, IAbilityChangeStats stats)
        {
            switch (stats.StatType)
            {
                case StatsType.MoveSpeed:
                    MoveSpeed.AddChangeStat(id, stats.StatsChangeType, stats.Value);
                    break;
                case StatsType.AttackSpeed :
                    AttackSpeed.AddChangeStat(id, stats.StatsChangeType, stats.Value);
                    break;
            }
        }

        public void DecreaseValue(int id, IAbilityChangeStats stats)
        {
            switch (stats.StatType)
            {
                case StatsType.MoveSpeed:
                    MoveSpeed.RemoveChangeStat(id);
                    break;
                case StatsType.AttackSpeed :
                    AttackSpeed.RemoveChangeStat(id);
                    break;
            }
        }
       
    }
}

using System.Collections.Generic;
using Game.Abstractions.Ability;
using Game.DataBase.Abilities.Logic;
using Game.DataBase.Units;
using UnityEngine;

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
        
        IFloatValue IStatsUnit.uMoveSpeed => MoveSpeed;
        IFloatValue IStatsUnit.uAttackSpeed => AttackSpeed;

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

       
    }
}

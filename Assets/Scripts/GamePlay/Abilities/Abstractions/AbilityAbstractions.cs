using UnityEngine;

namespace Game.Abstractions.Ability
{
    
    public interface IStatsUnit
    {
        int uHealth { get; set; }
        int uDamage { get; set; }
        IFloatValue uMoveSpeed { get; }
        IFloatValue uAttackSpeed { get; }
    }

    public interface IFloatValue
    {
        float uValue { get; }
        void AddChangeStat(int id, IAbilityChangeStats stat);
        void RemoveChangeStat(int id);
    }

    public interface IAbilityChangeStats
    {
        public StatsType statType { get; }
        StatsChangeType StatsChangeType { get; }
        float Value { get; }
    }

    public enum StatsChangeType
    {
        Additive,
        Multiplicative
    }
    
    public enum StatsType
    {
        // Health = 0,
        // Damage = 1,
        MoveSpeed = 2,
        AttackSpeed = 3
    }

    public interface IAbilityTarget
    {
        IStatsUnit Stats { get; }
        
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Game.Abstractions.Ability
{
    
    public interface IStatsUnit
    {
        int uHealth { get; set; }
        int uDamage { get; set; }
        IFloatValue uMoveSpeed { get; set; }
        IFloatValue uAttackSpeed { get; set; }
        void IncreaseValue(int id, IAbilityChangeStats stats);
        void DecreaseValue(int id, IAbilityChangeStats stats);
    }

    public interface IFloatValue
    {
        float uValue { get; }
        void AddChangeStat(int id, StatsChangeType changeType, float value);
        void RemoveChangeStat(int id);
    }

    public interface IAbilityChangeStats
    {
        public StatsType StatType { get; }
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
        IStatsUnit Stats { get; set; }
        void Die();
        void TakeDamage(int damage);
        int Faction { get; }
        Vector3 Position { get; }
    }

    public interface IAbilitiesSystemProvider
    {
        IReadOnlyList<IAbilityTarget> AllUnits { get; }
    }
}

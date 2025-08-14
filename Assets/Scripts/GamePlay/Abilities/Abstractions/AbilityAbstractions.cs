using System.Collections.Generic;
using UnityEngine;

namespace Game.Abstractions.Ability
{
    
    public interface IStatsUnit
    {
        int Health { get; set; }
        int Damage { get; set; }
        float MoveSpeed { get; }
        float AttackSpeed { get; }
        float ReceiveDamageResistance { get; }
        void IncreaseValue(int id, StatsType statType, StatsChangeType changeType, float value);
        void DecreaseValue(int id, IAbilityChangeStats stats);
    }

    public interface IFloatValue
    {
        float Value { get; }
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
        Percentage
    }
    
    public enum StatsType
    {
        // Health = 0,
        // Damage = 1,
        MoveSpeed = 2,
        AttackSpeed = 3,
        DamageResistance = 4
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

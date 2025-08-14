using Game.Abstractions.Ability;
using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Units;
using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Units
{
    public interface IAttackable
    {
        IStatsUnit Stats { get; }
        UnitsSystem UnitsSystem { get; }
        Transform UnitTransform { get; }
        int Faction { get; }
    }
}

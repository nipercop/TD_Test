using Game.GamePlayCore.Stats;
using Game.GamePlayCore.Systems.Units;
using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Units
{
    public interface IAttackable
    {
        StatsUnit Stats { get; }
        UnitsSystem UnitsSystem { get; }
        Transform UnitTransform { get; }
    }
}

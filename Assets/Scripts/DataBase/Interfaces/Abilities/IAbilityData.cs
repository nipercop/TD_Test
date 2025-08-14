using Game.DataBase.Abilities.Logic;
using UnityEngine;

namespace Game.DataBase.Abilities
{
    public interface IAbilityData
    {
        int Id { get; }
        string Name { get; }
        float Duration { get; }
        float TickTime { get; }
        int MaxStacks { get; }
        float CoolDown { get; }
        AbilityLogicCore[] Logics { get; }
        AbilityType abilityType { get; }
        
    }
}

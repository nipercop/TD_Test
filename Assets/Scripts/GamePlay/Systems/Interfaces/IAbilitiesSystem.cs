using System;
using Game.GamePlayCore.Abilities;
using UnityEngine;

namespace Game.GamePlayCore.Interfaces.Abilities
{
    public interface IAbilitiesSystem
    {
        public AbilityCore[] Datas { get; }
        event Action AbilitiesLoaded;
    }
}

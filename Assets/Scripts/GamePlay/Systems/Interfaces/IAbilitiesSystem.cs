using System;
using Game.GamePlayCore.Abilities;
using Game.GamePlayCore.Units;

namespace Game.GamePlayCore.Interfaces.Abilities
{
    public interface IAbilitiesSystem
    {
        public AbilityCore[] Datas { get; }
        event Action AbilitiesLoaded;
        
        void ActivateAbility(int id);
        void ActivateAbility(int id, DamagableUnit target);
    }
}

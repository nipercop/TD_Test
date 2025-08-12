using Game.GamePlayCore.Abilities;
using Game.GamePlayCore.Interfaces.Abilities;
using System;

namespace Game.UI.Abilities.Model
{
    public class AbilityPanelModel
    {
        private readonly IAbilitiesSystem _abilitiesSystem;
        public event Action<AbilityCore[]> OnAbilitiesLoaded;

        public AbilityPanelModel(IAbilitiesSystem abilitiesSystem)
        {
            _abilitiesSystem = abilitiesSystem;
            _abilitiesSystem.AbilitiesLoaded += LoadAbilities;
        }

        private void LoadAbilities()
        {
            _abilitiesSystem.AbilitiesLoaded -= LoadAbilities;
            OnAbilitiesLoaded?.Invoke(_abilitiesSystem.Datas);
        }

        public AbilityCore[] GetAbilities()
        {
            return _abilitiesSystem.Datas;
        }

    }
}

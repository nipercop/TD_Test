using System;
using Game.GamePlayCore.Abilities;
using Game.GamePlayCore.Interfaces.Abilities;
using Game.GamePlayCore.Systems.Units;
using Game.UI.Abilities.Model;
using Game.UI.Abilities.View;

namespace Game.UI.Abilities.Presenter
{
    public class AbilityPanelPresenter : IDisposable
    {
        
        private AbilityPanelView _view;
        private readonly AbilityPanelModel _model;
        private readonly IAbilitiesSystem _abilitiesSystem;
        private readonly UnitsSystem  _unitsSystem;

        public AbilityPanelPresenter(AbilityPanelModel model,  IAbilitiesSystem abilitiesSystem, UnitsSystem  unitsSystem)
        {
            _unitsSystem = unitsSystem;
            _abilitiesSystem = abilitiesSystem;
            _model = model;
            _model.OnAbilitiesLoaded += OnAbilitiesLoaded;
        }

        public void SetView(AbilityPanelView view)
        {
            _view = view;
        }

        private void OnAbilitiesLoaded(AbilityCore[] abilities)
        {
            foreach (var ability in abilities)
            {
                _view.ShowAbility(ability);
            }
        }

        public void OnAbilityClicked(int abilityId)
        {
            int myFaction = abilityId != 3 ? 0 : 1; // TODO: temp code
            var units = _unitsSystem.AllUnits;
            foreach (var unit in units)
            {
                if (unit.Faction == myFaction)
                {
                    _abilitiesSystem.ActivateAbility(abilityId, unit);
                }
            }
            _view.RemoveAbility(abilityId);
        }

        public void Dispose()
        {
            _view = null;
            _model.OnAbilitiesLoaded -= OnAbilitiesLoaded;
        }
    }
}

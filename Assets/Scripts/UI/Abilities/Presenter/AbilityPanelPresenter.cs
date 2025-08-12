using System;
using Game.GamePlayCore.Abilities;
using Game.GamePlayCore.Interfaces.Abilities;
using Game.UI.Abilities.Model;
using Game.UI.Abilities.View;
using UnityEngine;

namespace Game.UI.Abilities.Presenter
{
    public class AbilityPanelPresenter : IDisposable
    {
        
        private AbilityPanelView _view;
        private readonly AbilityPanelModel _model;
        private readonly IAbilitiesSystem _abilitiesSystem;

        public AbilityPanelPresenter(AbilityPanelModel model)
        {
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
            Debug.Log("OnAbilityClicked = "+ abilityId);
        }

        public void Dispose()
        {
            _view = null;
            _model.OnAbilitiesLoaded -= OnAbilitiesLoaded;
        }
    }
}

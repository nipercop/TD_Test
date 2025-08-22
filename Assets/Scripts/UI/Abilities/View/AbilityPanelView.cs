using System.Collections.Generic;
using Game.GamePlayCore.Abilities;
using Game.UI.Abilities.Presenter;
using UnityEngine;
using VContainer;

namespace Game.UI.Abilities.View
{
    public class AbilityPanelView : MonoBehaviour
    {
        private AbilityPanelPresenter _presenter;
        [SerializeField] GameObject _abilityButtonPrefab;
        List<AbilityButtonView>  _abilityButtons = new List<AbilityButtonView>();
        
        [Inject]
        public void Construct(AbilityPanelPresenter presenter)
        {
            _presenter = presenter;
            _presenter.SetView(this);
        }

        public void ShowAbility(AbilityCore ability)
        {
            var abv = Instantiate(_abilityButtonPrefab, transform).GetComponent<AbilityButtonView>();
            abv.SetData(ability.Id, ability.Name , OnAbilityClicked);
            _abilityButtons.Add(abv);
        }

        public void RemoveAbility(int abilityId)
        {
            for (int i = _abilityButtons.Count -1; i >=0 ; i--)
            {
                if (abilityId == _abilityButtons[i].Id)
                {
                    Destroy(_abilityButtons[i].gameObject);
                    _abilityButtons.RemoveAt(i);
                }
            }
        }
        
        private void OnAbilityClicked(int abilityId)
        {
            _presenter.OnAbilityClicked(abilityId);
        }

        private void OnDestroy()
        {
            _presenter?.Dispose();
        }

        void Update()
        {
        
        }
    }
}

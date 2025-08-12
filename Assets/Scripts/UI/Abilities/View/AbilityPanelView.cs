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
        }
        
        private void OnAbilityClicked(int abilityId)
        {
            _presenter.OnAbilityClicked(abilityId);
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
        }

        void Update()
        {
        
        }
    }
}

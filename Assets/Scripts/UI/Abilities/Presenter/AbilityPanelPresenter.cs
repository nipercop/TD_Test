using Game.UI.Abilities.Model;
using Game.UI.Abilities.View;
using UnityEngine;

namespace Game.UI.Abilities.Presenter
{
    public class AbilityPanelPresenter
    {
        private AbilityPanelView _view;
        private AbilityPanelModel _model;
        
        public AbilityPanelPresenter(AbilityPanelView view)
        {
            _view = view;
            _model = new AbilityPanelModel();
        }
    }
}

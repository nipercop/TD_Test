using Game.UI.Abilities.Presenter;
using UnityEngine;

namespace Game.UI.Abilities.View
{
    public class AbilityPanelView : MonoBehaviour
    {
        
        AbilityPanelPresenter  _presenter;
        
        void Start()
        {
            _presenter = new AbilityPanelPresenter(this);
        }

        
        void Update()
        {
        
        }
    }
}

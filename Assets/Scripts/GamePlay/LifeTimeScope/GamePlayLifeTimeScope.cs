using Game.UI.Abilities.Model;
using Game.UI.Abilities.Presenter;
using Game.UI.Abilities.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.LifeTimeScope.GamePlayCore
{
    public class GamePlayLifeTimeScope : LifetimeScope
    {
        
        protected override void Configure(IContainerBuilder builder)
        {
            
            
            builder.Register<AbilityPanelModel>(Lifetime.Transient);
            builder.Register<AbilityPanelPresenter>(Lifetime.Transient);
            builder.RegisterComponentInHierarchy<AbilityPanelView>();
            
        }
        
    }
}

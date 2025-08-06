using Game.GamePlayCore.Interfaces.Systems;
using Game.GamePlayCore.Systems.Updater;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.LifeTimeScope.GamePlayCore
{
    public class GamePlayLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GamePlayUpdater>(Lifetime.Scoped).As<IGamePlayUpdater>();
        }
    }
}

using Game.DataBase.Loader;
using Game.GamePlayCore.Interfaces.Systems;
using Game.GamePlayCore.Interfaces.Systems.Spawners;
using Game.GamePlayCore.Systems.GamePlayState;
using Game.GamePlayCore.Systems.Spawners;
using Game.GamePlayCore.Systems.Units;
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
            builder.Register<ScriptableObjectLoader>(Lifetime.Singleton).AsSelf();
            builder.RegisterComponentInHierarchy<GamePlayUpdater>().As<IGamePlayUpdater>();
            builder.Register<EnemySpawnerSystem>(Lifetime.Scoped).As<ISpawnerSystem>();
            builder.RegisterComponentInHierarchy<GamePlayStateSystem>();
            builder.RegisterComponentInHierarchy<UnitsSystem>();
        }
    }
}

using _Assets.Scripts.Configs;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.UIs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class RootInstaller : LifetimeScope
    {
        [SerializeField] private ConfigProvider configProvider;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(configProvider);

            builder.Register<MazeParser>(Lifetime.Singleton);
            builder.Register<GridModel>(Lifetime.Singleton);
            builder.Register<ScoreModel>(Lifetime.Singleton);
            builder.Register<PacmanMoveModel>(Lifetime.Singleton);

            builder.Register<SceneSerivce>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}
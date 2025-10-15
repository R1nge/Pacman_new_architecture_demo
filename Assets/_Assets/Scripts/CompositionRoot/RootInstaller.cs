using _Assets.Scripts.Configs;
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
            var map = new GridModel(31, 28);
            builder.RegisterInstance<GridModel>(map);
            builder.Register<PacmanMoveModel>(Lifetime.Singleton);
            builder.RegisterComponent(configProvider);
            builder.Register<SceneSerivce>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}
using _Assets.Scripts.Ecs;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.StateMachine.StatesCreators;
using _Assets.Scripts.Services.UIs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class MainSceneInstaller : LifetimeScope
    {
        [SerializeField] private InjectableInstaller injectableInstaller;
        [SerializeField] private SoundService soundService;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(soundService);
            builder.RegisterComponent(injectableInstaller);

            builder.Register<WindowFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<WindowManager>().AsSelf();

            builder.Register<MazeService>(Lifetime.Singleton);
            builder.Register<PacmanService>(Lifetime.Singleton);
            builder.Register<ScoreService>(Lifetime.Singleton);

            builder.Register<WallSpawner>(Lifetime.Singleton);
            builder.Register<BallSpawner>(Lifetime.Singleton);
            builder.Register<WarpPortalSpawner>(Lifetime.Singleton);

            builder.Register<MainMenuStatesFactory>(Lifetime.Singleton);
            builder.Register<MainSceneStateCreator>(Lifetime.Singleton);
        }
    }
}
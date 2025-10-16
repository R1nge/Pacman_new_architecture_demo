using _Assets.Scripts.Services;
using _Assets.Scripts.Services.StateMachine;
using _Assets.Scripts.Services.StateMachine.StatesCreators;
using _Assets.Scripts.Services.UIs;
using VContainer;
using VContainer.Unity;

namespace _Assets.Scripts.CompositionRoot
{
    public class MainSceneInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<WindowFactory>(Lifetime.Singleton);
            builder.RegisterEntryPoint<WindowManager>().AsSelf();

            builder.Register<MapService>(Lifetime.Singleton);
            builder.Register<PacmanService>(Lifetime.Singleton);
            builder.Register<ScoreService>(Lifetime.Singleton);

            builder.Register<WallSpawner>(Lifetime.Singleton);
            builder.Register<BallSpawner>(Lifetime.Singleton);

            builder.Register<MainMenuStatesFactory>(Lifetime.Singleton);
            builder.Register<MainSceneStateCreator>(Lifetime.Singleton);
        }
    }
}
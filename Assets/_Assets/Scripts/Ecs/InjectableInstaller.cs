#if MORPEH
using _Assets.Scripts.Ecs.Movement.Systems;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs
{
    public class InjectableInstaller : MonoBehaviour
    {
        [Inject] private IObjectResolver _container;

        private World world;

        private void Start()
        {
            world = World.Default;

            var updateGroup = world.CreateSystemsGroup();
            
            var pacmanInputSystem = new PacmanInputSystem();
            _container.Inject(pacmanInputSystem);
            updateGroup.AddSystem(pacmanInputSystem);

            var movementSystem = new PacmanMovementSystem();
            _container.Inject(movementSystem);
            updateGroup.AddSystem(movementSystem);

            var pacmanInputCleanupSystem = new PacmanInputCleanupSystem();
            _container.Inject(pacmanInputCleanupSystem);
            updateGroup.AddSystem(pacmanInputCleanupSystem);

            world.AddSystemsGroup(order: 0, updateGroup);
        }
    }
}
#endif
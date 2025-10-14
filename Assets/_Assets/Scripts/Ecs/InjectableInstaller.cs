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
            var systemsGroup = world.CreateSystemsGroup();
            var movementSystem = new PacmanMovementSystem();
            _container.Inject(movementSystem);
            systemsGroup.AddSystem(movementSystem);
            world.AddSystemsGroup(order: 0, systemsGroup);
        }
    }
}
#endif
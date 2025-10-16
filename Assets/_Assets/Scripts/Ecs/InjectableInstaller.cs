#if MORPEH
using System.Collections;
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

        private IEnumerator Start()
        {
            world = World.Default;

            var updateGroup = world.CreateSystemsGroup();
            
            var pacmanInputSystem = new PacmanInputSystem();
            _container.Inject(pacmanInputSystem);
            updateGroup.AddSystem(pacmanInputSystem);

            var pacmanScoreSystem = new PacmanFieldScoreSystem();
            _container.Inject(pacmanScoreSystem);
            updateGroup.AddSystem(pacmanScoreSystem);

            var movementSystem = new PacmanMovementSystem();
            _container.Inject(movementSystem);
            updateGroup.AddSystem(movementSystem);

            //var pacmanInputCleanupSystem = new PacmanInputCleanupSystem();
            //_container.Inject(pacmanInputCleanupSystem);
            //updateGroup.AddSystem(pacmanInputCleanupSystem);

            yield return new WaitForSeconds(5);

            world.AddSystemsGroup(order: 0, updateGroup);
        }
    }
}
#endif
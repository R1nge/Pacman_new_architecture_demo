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

        public void Init()
        {
            world = World.Default;

            var updateGroup = world.CreateSystemsGroup();
            
            var pacmanInputSystem = new PacmanInputSystem();
            _container.Inject(pacmanInputSystem);
            updateGroup.AddSystem(pacmanInputSystem);

            var pacmanScoreSystem = new PacmanFieldScoreSystem();
            _container.Inject(pacmanScoreSystem);
            updateGroup.AddSystem(pacmanScoreSystem);

            var warpSystem = new WarpSystem();
            _container.Inject(warpSystem);
            updateGroup.AddSystem(warpSystem);

            var movementSystem = new PacmanMovementSystem();
            _container.Inject(movementSystem);
            updateGroup.AddSystem(movementSystem);

            //var pacmanInputCleanupSystem = new PacmanInputCleanupSystem();
            //_container.Inject(pacmanInputCleanupSystem);
            //updateGroup.AddSystem(pacmanInputCleanupSystem);

            world.AddSystemsGroup(order: 0, updateGroup);
        }
    }
}
#endif
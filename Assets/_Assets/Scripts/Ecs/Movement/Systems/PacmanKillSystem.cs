using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class PacmanKillSystem : ISystem
    {
        [Inject] private PacmanService _pacmanService;
        private Filter _filter;
        private Stash<MovementComponent> _movementStash;
        public World World { get; set; }

        public void Dispose()
        {
            // TODO release managed resources here
        }

        public void OnAwake()
        {
            _filter = World.Filter.With<ClydeTag>().With<MovementComponent>().Build();
            _movementStash = World.GetStash<MovementComponent>();
        }


        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref _movementStash.Get(entity);

                if (moveComponent.TargetPosition == _pacmanService.GetPacmanPosition())
                {
                    Debug.LogError("Gameover");               
                }
            }
        }
    }
}
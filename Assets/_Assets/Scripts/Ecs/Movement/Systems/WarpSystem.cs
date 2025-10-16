using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Services;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class WarpSystem : ISystem
    {
        private Filter _filter;
        private Stash<MovementComponent> _moveStash;
        [Inject] private MazeService _mazeService;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<MovementComponent>().Build();
            _moveStash = World.GetStash<MovementComponent>();
        }
        
        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref _moveStash.Get(entity);
                var warp = _mazeService.TryWarp(moveComponent.CurrentPosition);
                if (warp.Item1)
                {
                    moveComponent.CurrentPosition = warp.Item2;
                    moveComponent.TargetPosition = warp.Item2;
                    moveComponent.CurrentLerpDuration = moveComponent.LerpDuration;
                    Debug.Log($"warp {warp.Item2}");
                }
            }
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}
using _Assets.Scripts.Configs;
using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using _Assets.Scripts.Services.UIs;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PacmanMovementSystem : ISystem
    {
        [Inject] private PacmanService _pacmanService;
        [Inject] private MazeService _mazeService;
        private Filter _filter;
        private Stash<MovementComponent> _movementStash;
        private Stash<InputComponent> _inputStash;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PacManTag>().With<InputComponent>().With<MovementComponent>().Build();
            _movementStash = World.GetStash<MovementComponent>();
            _inputStash = World.GetStash<InputComponent>();
        }


        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref _movementStash.Get(entity);
                ref var inputComponent = ref _inputStash.Get(entity);

                if (moveComponent.CurrentLerpDuration > moveComponent.LerpDuration)
                {
                    moveComponent.CurrentLerpDuration = 0;
                    moveComponent.CurrentPosition = moveComponent.TargetPosition;
                    _pacmanService.SetPacmanPosition(moveComponent.CurrentPosition);
                    //if can move
                    if (_mazeService.GetCellType((int)(moveComponent.TargetPosition.x + inputComponent.Direction.x), (int)(moveComponent.TargetPosition.y + inputComponent.Direction.y)) != CellModel.CellType.Wall)
                    {
                        moveComponent.TargetPosition += inputComponent.Direction;
                        _pacmanService.SetPacmanTargetPosition(moveComponent.TargetPosition);
                    }
                }
                else
                {
                    moveComponent.CurrentPosition = math.lerp(moveComponent.CurrentPosition, moveComponent.TargetPosition, moveComponent.CurrentLerpDuration / moveComponent.LerpDuration);
                    moveComponent.Transform.position = moveComponent.CurrentPosition;
                    _pacmanService.SetPacmanPosition(moveComponent.CurrentPosition);
                    moveComponent.CurrentLerpDuration += deltaTime;
                }
            }
        }


        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}
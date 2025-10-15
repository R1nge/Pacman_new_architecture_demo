using _Assets.Scripts.Configs;
using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
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
        [Inject] private ConfigProvider _configProvider;
        [Inject] private PacmanMoveModel pacmanMoveModel;
        [Inject] private GridModel _mapModel;
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
                    pacmanMoveModel.CurrentPosition.Value = moveComponent.CurrentPosition;
                    //if can move
                    if (!_mapModel._cells[(int)(moveComponent.TargetPosition.x + inputComponent.Direction.x), (int)(moveComponent.TargetPosition.y + inputComponent.Direction.y)].IsWall)
                    {
                        //TODO:
                        //In the original pacman didn't change the position and just continued on.
                        //So, need to move this check into input system
                        moveComponent.TargetPosition += inputComponent.Direction;
                        pacmanMoveModel.TargetPosition.Value = moveComponent.TargetPosition;
                    }
                }
                else
                {
                    moveComponent.CurrentPosition = math.lerp(moveComponent.CurrentPosition, moveComponent.TargetPosition, moveComponent.CurrentLerpDuration / moveComponent.LerpDuration);
                    moveComponent.Transform.position = moveComponent.CurrentPosition;
                    pacmanMoveModel.CurrentPosition.Value = moveComponent.CurrentPosition;
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
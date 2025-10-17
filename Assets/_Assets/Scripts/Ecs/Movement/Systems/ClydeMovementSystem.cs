using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using Scellecs.Morpeh;
using Unity.Mathematics;
using UnityEngine;
using VContainer;
using Random = Unity.Mathematics.Random;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class ClydeMovementSystem : ISystem
    {
        [Inject] private MazeService _mazeService;
        private Filter _filter;
        private Stash<MovementComponent> _movementStash;
        private Random _random;
        public World World { get; set; }

        public void OnAwake()
        {
            _random = Random.CreateFromIndex(123);
            _filter = World.Filter.With<ClydeTag>().With<MovementComponent>().Build();
            _movementStash = World.GetStash<MovementComponent>();
        }


        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref _movementStash.Get(entity);

                if (moveComponent.CurrentLerpDuration > moveComponent.LerpDuration)
                {
                    moveComponent.CurrentLerpDuration = 0;
                    moveComponent.CurrentPosition = moveComponent.TargetPosition;
                    //if can move
                    var direction = GetDirection(Vector3.up);

                    while (!CanMove(direction, ref moveComponent))
                    {
                        direction = GetDirection(direction);
                    }

                    moveComponent.TargetPosition += direction;
                }
                else
                {
                    moveComponent.CurrentPosition = math.lerp(moveComponent.CurrentPosition,
                        moveComponent.TargetPosition, moveComponent.CurrentLerpDuration / moveComponent.LerpDuration);
                    moveComponent.Transform.position = moveComponent.CurrentPosition;
                    moveComponent.CurrentLerpDuration += deltaTime;
                }
            }
        }

        private Vector3 GetDirection(Vector3 currentDirection)
        {
            var dir = _random.NextInt(0, 4);
            switch (dir)
            {
                case 0:
                    currentDirection = Vector3.up;
                    break;
                case 1:
                    currentDirection = Vector3.left;
                    break;
                case 2:
                    currentDirection = Vector3.right;
                    break;
                case 3:
                    currentDirection = Vector3.down;
                    break;
            }

            return currentDirection;
        }

        private bool CanMove(Vector3 direction, ref MovementComponent moveComponent)
        {
            return _mazeService.GetCellType((int)(moveComponent.TargetPosition.x + direction.x),
                (int)(moveComponent.TargetPosition.y + direction.y)) != CellModel.CellType.Wall;
        }


        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}
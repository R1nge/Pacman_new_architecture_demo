using _Assets.Scripts.Configs;
using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
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
        [Inject] private MoveModel _moveModel;
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
                Debug.Log($"Position: {moveComponent.Position}; Speed: {_configProvider.Speed}");
                ref var inputComponent = ref _inputStash.Get(entity);

                Debug.Log($"Move rounded; X:{(int)(moveComponent.Position.x + inputComponent.Direction.x)},{(int)(moveComponent.Position.y + inputComponent.Direction.y)} Is wall: {_mapModel._cells[(int)math.round(moveComponent.Position.x), (int)math.round(moveComponent.Position.y)].IsWall}");
                if (!_mapModel._cells[(int)(moveComponent.Position.x + inputComponent.Direction.x), (int)(moveComponent.Position.y + inputComponent.Direction.y)].IsWall)
                {
                    moveComponent.Position += inputComponent.Direction; //* _configProvider.Speed * deltaTime;
                    moveComponent.Transform.position = moveComponent.Position;
                    _moveModel.Position.Value = moveComponent.Position;
                }
            }
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}
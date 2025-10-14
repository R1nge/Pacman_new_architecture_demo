using _Assets.Scripts.Configs;
using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Services.UIs;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class MovementSystem : ISystem
    {
        [Inject] private ConfigProvider _configProvider;
        [Inject] private MoveModel _moveModel;
        private Filter _filter;
        private Stash<MovementComponent> _movementStash;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<MovementComponent>().Build();
            _movementStash = World.GetStash<MovementComponent>();
        }


        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var moveComponent = ref _movementStash.Get(entity);
                Debug.Log($"Position: {moveComponent.Position}; Speed: {_configProvider.Speed}");
                moveComponent.Position += Vector3.right * _configProvider.Speed;
                moveComponent.Transform.position = moveComponent.Position;
                _moveModel.Position.Value = moveComponent.Position;
            }
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }
    }
}
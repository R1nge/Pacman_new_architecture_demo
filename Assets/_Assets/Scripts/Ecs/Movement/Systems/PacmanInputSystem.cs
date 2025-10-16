using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
using _Assets.Scripts.Services;
using _Assets.Scripts.Services.Models;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PacmanInputSystem : ISystem
    {
        [Inject] private MazeService mazeService;
        [Inject] private PacmanService _pacmanService;
        private Filter _filter;
        private Stash<InputComponent> _inputStash;
        private Vector3 _tempDirection;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PacManTag>().With<InputComponent>().Build();
            _inputStash = World.GetStash<InputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var inputComponent = ref _inputStash.Get(entity);

                if (Keyboard.current.wKey.isPressed)
                {
                    _tempDirection = Vector3.up;
                }
                else if (Keyboard.current.aKey.isPressed)
                {
                    _tempDirection = Vector3.left;
                }
                else if (Keyboard.current.sKey.isPressed)
                {
                    _tempDirection = Vector3.down;
                }
                else if (Keyboard.current.dKey.isPressed)
                {
                    _tempDirection = Vector3.right;
                }

                if (mazeService.GetCellType((int)(_pacmanService.GetPacmanPosition().x + _tempDirection.x), (int)(_pacmanService.GetPacmanPosition().y + _tempDirection.y)) != CellModel.CellType.Wall || 
                    mazeService.GetCellType((int)(_pacmanService.GetPacmanTargetPosition().x + _tempDirection.x), (int)(_pacmanService.GetPacmanTargetPosition().y + _tempDirection.y)) != CellModel.CellType.Wall)
                {
                    inputComponent.Direction = _tempDirection;
                }
                else
                {
                    _tempDirection = inputComponent.Direction;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
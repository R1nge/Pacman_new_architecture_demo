using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PacmanInputSystem : ISystem
    {
        private Filter _filter;
        private Stash<InputComponent> _inputStash;
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
                    inputComponent.Direction = Vector3.up;
                }
                else if (Keyboard.current.aKey.isPressed)
                {
                    inputComponent.Direction = Vector3.left;
                }
                else if (Keyboard.current.sKey.isPressed)
                {
                    inputComponent.Direction = Vector3.down;
                }
                else if (Keyboard.current.dKey.isPressed)
                {
                    inputComponent.Direction = Vector3.right;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}
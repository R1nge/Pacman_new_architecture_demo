using _Assets.Scripts.Ecs.Movement.Components;
using _Assets.Scripts.Ecs.Tags;
using Scellecs.Morpeh;
using UnityEngine;

namespace _Assets.Scripts.Ecs.Movement.Systems
{
    public class PacmanInputCleanupSystem : ICleanupSystem
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
                inputComponent.Direction = Vector3.zero;
                Debug.Log("Cleanup");
            }
        }

        public void Dispose()
        {
        }
    }
}
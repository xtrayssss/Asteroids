using Components.Move;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Systems.Move
{
    internal class BlockMovementSystem : IEcsRunSystem
    {
        private readonly ScreenPoints _screenPoints;
        private readonly EcsFilter<ModelComponent> _filter;

        public BlockMovementSystem(ScreenPoints screenPoints) => 
            _screenPoints = screenPoints;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var modelComponent = ref _filter.Get1(indexEntity);

                Vector3 position = modelComponent.Transform.position;

                modelComponent.Transform.position = new Vector3(
                    Mathf.Clamp(position.x, _screenPoints.LeftXScreen.x, _screenPoints.RightXScreen.x),
                    position.y);
            }
        }
    }
}
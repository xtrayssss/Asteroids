using Components.Move;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Components.Bounds
{
    internal class BoundariesScreenSystem : IEcsRunSystem
    {
        private readonly ScreenPoints _screenPoints;
        private readonly EcsFilter<CanBeyondBordersComponent, ModelComponent> _filter;

        public BoundariesScreenSystem(ScreenPoints screenPoints) => 
            _screenPoints = screenPoints;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var canBeyondBordersComponent = ref _filter.Get1(indexEntity);
                ref var modelComponent = ref _filter.Get2(indexEntity);

                if (modelComponent.Transform.position.y < _screenPoints.ScreenLowestPoint.y ||
                    modelComponent.Transform.position.y > _screenPoints.ScreenHighestPoint.y)
                {
                    canBeyondBordersComponent.CanBeyondBorders.HandlerBeyondBorders(_filter.GetEntity(indexEntity));
                }
            }
        }
    }
}
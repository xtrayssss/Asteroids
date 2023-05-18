using System;
using Components.Move;
using Leopotam.Ecs;
using MonoBehaviours;

namespace Systems.Move
{
    internal class SwapDirectionSystem : IEcsRunSystem
    {
        private readonly ScreenPoints _screenPoints;

        private readonly EcsFilter<MovementDirectionComponent, ModelComponent, SwapDirectionComponent>.Exclude<
            SwapDirectionBlockTimer> _filter;

        public SwapDirectionSystem(ScreenPoints screenPoints) =>
            _screenPoints = screenPoints;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var movementDirectionComponent = ref _filter.Get1(indexEntity);
                ref var modelComponent = ref _filter.Get2(indexEntity);
                ref var swapDirectionComponent = ref _filter.Get3(indexEntity);

                if (Math.Abs(_screenPoints.LeftXScreen.x - modelComponent.Transform.position.x) <
                    swapDirectionComponent.Threshold ||
                    Math.Abs(_screenPoints.RightXScreen.x - modelComponent.Transform.position.x) <
                    swapDirectionComponent.Threshold)
                {
                    movementDirectionComponent.Direction.x *= -1;

                    _filter.GetEntity(indexEntity).Get<SwapDirectionBlockTimer>().Time =
                        swapDirectionComponent.TimeBlock;
                }
            }
        }
    }
}
using Components.Move;
using Leopotam.Ecs;

namespace Systems.Move
{
    internal class IncreaseSpeedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpeedComponent, IncreaseSpeedComponent> _filter;
        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var speedComponent = ref _filter.Get1(indexEntity);
                ref var increaseSpeedComponent = ref _filter.Get2(indexEntity);

                speedComponent.Speed += increaseSpeedComponent.AddValue * increaseSpeedComponent.Multiplier;
            }
        }
    }
}
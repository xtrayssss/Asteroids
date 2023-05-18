using Components.Move;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Move
{
    internal class SwapDirectionBlockTimerTickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SwapDirectionBlockTimer> _filter;
        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var swapDirectionBlockTimer = ref _filter.Get1(indexEntity);
                
                swapDirectionBlockTimer.Time -= Time.deltaTime;

                if (swapDirectionBlockTimer.Time <= 0.0f)
                {
                    _filter.GetEntity(indexEntity).Del<SwapDirectionBlockTimer>();
                }
            }
        }
    }
}
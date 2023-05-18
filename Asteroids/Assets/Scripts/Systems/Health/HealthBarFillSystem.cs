using Components.Health;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Systems.Health
{
    internal class HealthBarFillSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthBarComponent, StartFillProgress> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var healthBarComponent = ref _filter.Get1(indexEntity);

                healthBarComponent.FillImage.fillAmount = Mathf.SmoothDamp(healthBarComponent.FillImage.fillAmount,
                    healthBarComponent.TargetValue, ref healthBarComponent.Velocity,
                    healthBarComponent.SmoothTime * Time.deltaTime);
            }
        }
    }
}
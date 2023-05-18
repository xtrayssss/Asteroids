using Components.Destroy;
using Components.Health;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Health
{
    internal class HealthCheckerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<HealthChangedEvent, HealthComponent> _filter;
        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var healthComponent = ref _filter.Get2(indexEntity);

                if (healthComponent.Health <= 0)
                {
                    ref EcsEntity entity = ref _filter.GetEntity(indexEntity);

                    entity.Get<DeathHandlerComponent>().DeathHandler.DeathHandle(entity);
                }
            }
        }
    }
}
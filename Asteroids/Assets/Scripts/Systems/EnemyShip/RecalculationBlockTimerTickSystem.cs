using Components;
using Components.EnemyShip;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.EnemyShip
{
    internal class RecalculationBlockTimerTickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RecalculationBlockComponent>.Exclude<SpawnShipEnemyBlockTimer> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var recalculationBlockComponent = ref _filter.Get1(indexEntity);

                recalculationBlockComponent.Timer -= Time.deltaTime;

                if (recalculationBlockComponent.Timer <= 0.0f)
                {
                    _filter.GetEntity(indexEntity).Del<RecalculationBlockComponent>();
                }
            }
        }
    }
}
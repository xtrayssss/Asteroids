using Components.EnemyShip;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.EnemyShip
{
    internal class SpawnEnemyShipTimerTickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnShipEnemyBlockTimer> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var spawnShipEnemyBlockTimer = ref _filter.Get1(indexEntity);

                spawnShipEnemyBlockTimer.Timer -= Time.deltaTime;

                if (spawnShipEnemyBlockTimer.Timer <= 0.0f)
                {
                    _filter.GetEntity(indexEntity).Del<SpawnShipEnemyBlockTimer>();
                }
            }
        }
    }
}
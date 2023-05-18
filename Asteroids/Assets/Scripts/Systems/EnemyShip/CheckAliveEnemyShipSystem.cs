using System.Linq;
using Components;
using Components.EnemyShip;
using Configurations;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.EnemyShip
{
    internal class CheckAliveEnemyShipSystem : IEcsRunSystem
    {
        private readonly EnemyShipConfiguration _enemyShipConfiguration;

        private readonly
            EcsFilter<SpawnEntitiesComponent>.Exclude<RecalculationBlockComponent, SpawnShipEnemyBlockTimer> _filter;

        public CheckAliveEnemyShipSystem(EnemyShipConfiguration enemyShipConfiguration) =>
            _enemyShipConfiguration = enemyShipConfiguration;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var entity = ref _filter.GetEntity(indexEntity);
                
                ref var spawnEntitiesComponent = ref _filter.Get1(indexEntity);

                int countAliveEntities = spawnEntitiesComponent.EntitiesList.Count(x => x.IsAlive());

                entity.Get<RecalculationBlockComponent>().Timer = _enemyShipConfiguration.recalculationEntitiesTime;

                if (countAliveEntities == 0)
                {
                    entity.Get<SpawnEnemyShipEvent>();
                    spawnEntitiesComponent.EntitiesList.Clear();
                }
            }
        }
    }
}
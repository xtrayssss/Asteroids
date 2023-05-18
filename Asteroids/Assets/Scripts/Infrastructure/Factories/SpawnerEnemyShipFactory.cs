using Systems.EnemyShip;
using Components;
using Components.EnemyShip;
using Components.Projectile;
using Components.Tags;
using Configurations;
using Leopotam.Ecs;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure.Factories
{
    internal class SpawnerEnemyShipFactory : IFactory
    {
        private readonly EnemyShipConfiguration _enemyShipConfiguration;

        public void CreateEntity(EcsWorld world)
        {
            EcsEntity entity = world.NewEntity();

            entity.Get<EnemyShipSpawnerTag>();

            entity.Get<SpawnEnemyShipEvent>();
            
            ref var spawnProjectileComponent = ref entity.Get<SpawnProjectileComponent>();
            spawnProjectileComponent.MovementDirection = Vector2.down;

            entity.Get<SpawnEntitiesComponent>().Init(10);
            entity.Get<RecalculationBlockComponent>().Timer = _enemyShipConfiguration.recalculationEntitiesTime;
            
        }

        public SpawnerEnemyShipFactory(EnemyShipConfiguration enemyShipConfiguration) =>
            _enemyShipConfiguration = enemyShipConfiguration;
    }
}
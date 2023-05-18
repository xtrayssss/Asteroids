using Components.Destroy;
using Components.Move;
using Configurations;
using Leopotam.Ecs;
using UnityEngine;

namespace HandlerInterfaces
{
    internal class EnemyShipDeathHandler : IDeathHandler
    {
        private readonly EnemyShipConfiguration _enemyShipConfiguration;

        public EnemyShipDeathHandler(EnemyShipConfiguration enemyShipConfiguration) =>
            _enemyShipConfiguration = enemyShipConfiguration;

        public void DeathHandle(EcsEntity entity)
        {
            ref var modelComponent = ref entity.Get<ModelComponent>();

            GameObject explosionGO = Object.Instantiate(_enemyShipConfiguration.explosionPrefabs[
                Random.Range(0, _enemyShipConfiguration.explosionPrefabs.Length)]);

            explosionGO.transform.position = modelComponent.Transform.position;
            modelComponent.Transform.gameObject.SetActive(false);
            entity.Get<DestroyEvent>();
        }
    }
}
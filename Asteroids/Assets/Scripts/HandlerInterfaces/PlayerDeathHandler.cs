using Components.Destroy;
using Components.Move;
using Configurations;
using Leopotam.Ecs;
using UnityEngine;

namespace HandlerInterfaces
{
    internal class PlayerDeathHandler : IDeathHandler
    {
        private readonly GameObject _gameOverMenuGO;
        private readonly PlayerConfiguration _playerConfiguration;

        public PlayerDeathHandler(GameObject gameOverMenuGO, PlayerConfiguration playerConfiguration)
        {
            _gameOverMenuGO = gameOverMenuGO;
            _playerConfiguration = playerConfiguration;
        }

        public void DeathHandle(EcsEntity entity)
        {
            entity.Get<DestroyEvent>();
            _gameOverMenuGO.SetActive(true);
            
            ref var modelComponent = ref entity.Get<ModelComponent>();
            Object.Instantiate(_playerConfiguration.explosionPrefab).transform.position = modelComponent.Transform.position;

            modelComponent.Transform.gameObject.SetActive(false);
        }
    }
}
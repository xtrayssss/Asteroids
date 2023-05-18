using Configurations;
using Infrastructure.Factories;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Systems.Init
{
    internal class PlayerInitSystem : IEcsInitSystem
    {
        private readonly PlayerConfiguration _playerConfiguration;
        private readonly GameObject _poolContainer;
        private readonly EcsWorld _world;
        private readonly GameObject _gameOverMenuGO;
        private readonly ScreenPoints _screenPoints;

        private IFactory _factory;

        public PlayerInitSystem(PlayerConfiguration playerConfiguration, GameObject poolContainer,
            GameObject gameOverMenuGO, ScreenPoints screenPoints)
        {
            _playerConfiguration = playerConfiguration;
            _poolContainer = poolContainer;
            _gameOverMenuGO = gameOverMenuGO;
            _screenPoints = screenPoints;
        }

        public void Init()
        {
            _factory = new PlayerFactory(_playerConfiguration, _poolContainer, _gameOverMenuGO, _screenPoints);
            _factory.CreateEntity(_world);
        }
    }
}
using Configurations;
using Infrastructure.Factories;
using Leopotam.Ecs;
using UnityEngine.UI;

namespace Systems.Init
{
    internal class HealthBarInitSystem : IEcsInitSystem
    {
        private readonly Image _fillImage;
        private readonly PlayerConfiguration _playerConfiguration;

        private IFactory _factory;
        private EcsWorld _world;

        public HealthBarInitSystem(Image fillImage, PlayerConfiguration playerConfiguration)
        {
            _fillImage = fillImage;
            _playerConfiguration = playerConfiguration;
        }

        public void Init()
        {
            _factory = new HealthBarPlayerFactory(_fillImage, _playerConfiguration);
            _factory.CreateEntity(_world);
        }
    }
}
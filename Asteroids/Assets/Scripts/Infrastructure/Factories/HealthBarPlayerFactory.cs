using Components.Health;
using Configurations;
using Leopotam.Ecs;
using UnityEngine.UI;

namespace Infrastructure.Factories
{
    internal class HealthBarPlayerFactory : IFactory
    {
        private readonly Image _fillImage;
        private readonly PlayerConfiguration _playerConfiguration;

        public HealthBarPlayerFactory(Image fillImage, PlayerConfiguration playerConfiguration)
        {
            _fillImage = fillImage;
            _playerConfiguration = playerConfiguration;
        }

        public void CreateEntity(EcsWorld world)
        {
            var entity = world.NewEntity();

            ref var healthBarComponent = ref entity.Get<HealthBarComponent>();
            healthBarComponent.FillImage = _fillImage;
            healthBarComponent.FillImage.fillAmount = 1;
            healthBarComponent.SmoothTime = _playerConfiguration.smoothFillHpBar;

            _playerConfiguration.CurrentEntity.Get<HealthBarAttachedComponent>().HpBarEntity = entity;
        }
    }
}
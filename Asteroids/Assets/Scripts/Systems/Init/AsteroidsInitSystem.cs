using Configurations;
using Infrastructure.Factories;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Init
{
    internal class AsteroidsInitSystem : IEcsInitSystem
    {
        private readonly AsteroidConfiguration _asteroidConfiguration;
        private readonly GameObject _poolContainer;
        private readonly EcsWorld _world;
        private IFactory _factory;

        public AsteroidsInitSystem(AsteroidConfiguration asteroidConfiguration, GameObject poolContainer)
        {
            _asteroidConfiguration = asteroidConfiguration;
            _poolContainer = poolContainer;
        }

        public void Init()
        {
            _factory = new AsteroidsFactory(_asteroidConfiguration, _poolContainer);
            _factory.CreateEntity(_world);
        }
    }
}
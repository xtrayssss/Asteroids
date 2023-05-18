using Systems.EnemyShip;
using Configurations;
using Infrastructure.Factories;
using Leopotam.Ecs;

namespace Systems.Init
{
    internal class SpawnerShipEnemyInitSystem : IEcsInitSystem
    {
        private IFactory _factory;
        private readonly EnemyShipConfiguration _enemyShipConfiguration;
        private readonly EcsWorld _world;

        public SpawnerShipEnemyInitSystem(EnemyShipConfiguration enemyShipConfiguration) =>
            _enemyShipConfiguration = enemyShipConfiguration;

        public void Init()
        {
            _factory = new SpawnerEnemyShipFactory(_enemyShipConfiguration);
            _factory.CreateEntity(_world);
        }
    }
}
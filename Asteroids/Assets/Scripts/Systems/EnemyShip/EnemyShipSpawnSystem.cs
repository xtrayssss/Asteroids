using Systems.Projectile;
using Components.Damage;
using Components.Destroy;
using Components.EnemyShip;
using Components.Health;
using Components.Move;
using Components.Projectile;
using Components.Tags;
using Configurations;
using HandlerInterfaces;
using Leopotam.Ecs;
using MonoBehaviours;
using MonoBehaviours.Views;
using UnityEngine;

namespace Systems.EnemyShip
{
    internal class EnemyShipSpawnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;
        private readonly EcsFilter<SpawnEnemyShipEvent, SpawnProjectileComponent> _filter;

        private readonly EnemyShipConfiguration _enemyShipConfiguration;
        private readonly ScreenPoints _screenPoints;
        private readonly IDeathHandler _enemyShipDeathHandler;
        private readonly IConditionSpawnProjectile _conditionSpawnProjectile = new EnemyShipSpawnProjectileCondition();

        private readonly int[] _randomDirections =
        {
            -1,
            1
        };

        public EnemyShipSpawnSystem(EnemyShipConfiguration enemyShipConfiguration, ScreenPoints screenPoints)
        {
            _enemyShipConfiguration = enemyShipConfiguration;
            _screenPoints = screenPoints;
            _enemyShipDeathHandler = new EnemyShipDeathHandler(_enemyShipConfiguration);
        }

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var spawnProjectileComponent = ref _filter.Get2(indexEntity);

                for (int i = 0;
                    i < Random.Range(_enemyShipConfiguration.minAmountSpawnShipEnemy,
                        _enemyShipConfiguration.maxAmountSpawnShipEnemy);
                    i++)
                {
                    GameObject shipEnemyGO =
                        Object.Instantiate(_enemyShipConfiguration.enemiesPrefabs[
                            Random.Range(0, _enemyShipConfiguration.enemiesPrefabs.Length)]);

                    ref var spawnerEntity = ref _filter.GetEntity(indexEntity);

                    shipEnemyGO.transform.position = new Vector3(0,
                        _screenPoints.ScreenHighestPoint.y + _enemyShipConfiguration.spawnOffsetY);

                    EcsEntity shipEntity = _world.NewEntity();

                    shipEntity.Get<EnemyTag>();

                    shipEntity.Get<HealthComponent>().Health = Random.Range(_enemyShipConfiguration.minHealth,
                        _enemyShipConfiguration.maxHealth);

                    ref var spawnProjectileEnemyShipComponent = ref shipEntity.Get<SpawnProjectileComponent>();

                    spawnProjectileEnemyShipComponent.SpawnPoint =
                        shipEnemyGO.GetComponentInChildren<AttackPointMark>().transform;

                    EnemyShipSetProjectile(ref spawnProjectileEnemyShipComponent, ref spawnProjectileComponent);

                    shipEntity.Get<SpawnProjectileEvent>();

                    shipEntity.Get<MovementDirectionComponent>().Direction =
                        new Vector2(_randomDirections[Random.Range(0, _randomDirections.Length)], 0.0f);

                    shipEntity.Get<RigidbodyComponent>().Rigidbody = shipEnemyGO.GetComponent<Rigidbody2D>();

                    shipEntity.Get<SpeedComponent>().Speed = Random.Range(_enemyShipConfiguration.minSpeed,
                        _enemyShipConfiguration.maxSpeed);

                    shipEntity.Get<ModelComponent>().Transform = shipEnemyGO.transform;

                    shipEntity.Get<ProjectileSpawnConditionComponent>().ConditionSpawnProjectile =
                        _conditionSpawnProjectile;

                    shipEntity.Get<DeathHandlerComponent>().DeathHandler = _enemyShipDeathHandler;

                    shipEnemyGO.GetComponent<EnemyShipView>().Init(shipEntity);

                    shipEntity.Get<DamageableComponent>().Damageable = shipEnemyGO.GetComponent<IDamageable>();

                    ref var swapDirectionComponent = ref shipEntity.Get<SwapDirectionComponent>();
                    swapDirectionComponent.Threshold = _enemyShipConfiguration.swapDirectionDistance;
                    swapDirectionComponent.TimeBlock = _enemyShipConfiguration.timeSwapBlock;

                    spawnerEntity.Get<SpawnEntitiesComponent>().EntitiesList.Add(shipEntity);

                    shipEntity.Get<IncreaseSpeedProjectile>();
                }

                _filter.GetEntity(indexEntity).Get<SpawnShipEnemyBlockTimer>().Timer =
                    Random.Range(_enemyShipConfiguration.minSpawnFrequency, _enemyShipConfiguration.maxSpawnFrequency);
            }
        }

        private void EnemyShipSetProjectile(ref SpawnProjectileComponent spawnProjectileEnemyShipComponent,
            ref SpawnProjectileComponent spawnProjectileComponent)
        {
            spawnProjectileEnemyShipComponent.Speed = GetRandomProjectileData().speed;

            spawnProjectileEnemyShipComponent.Frequency = GetRandomProjectileData().frequency;

            spawnProjectileEnemyShipComponent.PrefabProjectile = GetRandomProjectileData().prefabProjectile;

            spawnProjectileEnemyShipComponent.MovementDirection = spawnProjectileComponent.MovementDirection;

            spawnProjectileEnemyShipComponent.Damage = GetRandomProjectileData().damage;

            spawnProjectileEnemyShipComponent.ProjectileIncreaseSpeedAddValue =
                _enemyShipConfiguration.ProjectileIncreaseSpeedAddValue;
            
            spawnProjectileEnemyShipComponent.ProjectileIncreaseSpeedMultiplier =
                _enemyShipConfiguration.projectileIncreaseSpeedMultiplier;
        }

        private ProjectileConfiguration GetRandomProjectileData() =>
            _enemyShipConfiguration
                .projectileConfigurations[Random.Range(0, _enemyShipConfiguration.projectileConfigurations.Length)];
    }
}
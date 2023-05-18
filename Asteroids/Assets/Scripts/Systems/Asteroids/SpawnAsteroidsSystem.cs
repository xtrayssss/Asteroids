using Components.Animator;
using Components.Asteroids;
using Components.Collider;
using Components.Damage;
using Components.Destroy;
using Components.Health;
using Components.Move;
using Components.Tags;
using Configurations;
using HandlerInterfaces;
using Leopotam.Ecs;
using MonoBehaviours;
using MonoBehaviours.Views;
using UnityEngine;

namespace Systems.Asteroids
{
    internal class SpawnAsteroidsSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<SpawnAsteroidsComponent, SpawnAsteroidsEvent>.Exclude<SpawnAsteroidsBlockTimer>
            _filter;

        private readonly AsteroidConfiguration _asteroidConfiguration;
        private readonly ScreenPoints _screenPoints;
        private readonly EcsWorld _world;

        private IDeathHandler _asteroidDeathHandler;

        public SpawnAsteroidsSystem(AsteroidConfiguration asteroidConfiguration, ScreenPoints screenPoints,
            EcsWorld world)
        {
            _asteroidConfiguration = asteroidConfiguration;
            _screenPoints = screenPoints;
            _world = world;
        }

        public void Init() =>
            _asteroidDeathHandler = new AsteroidDeathHandler(_world);

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var spawnAsteroidsComponent = ref _filter.Get1(indexEntity);

                for (int i = 0;
                    i < Random.Range(spawnAsteroidsComponent.MINSpawnAmountAsteroids,
                        spawnAsteroidsComponent.MAXAmountAsteroidsSpawn);
                    i++)
                {
                    GameObject asteroidGO = spawnAsteroidsComponent.PoolAsteroids.GetFreeObject();

                    asteroidGO.transform.position =
                        new Vector3(
                            Random.Range(_screenPoints.LeftXScreen.x + _asteroidConfiguration.leftSpawnOffset,
                                _screenPoints.RightXScreen.x + _asteroidConfiguration.rightSpawnOffset),
                            _screenPoints.ScreenHighestPoint.y);

                    float randomScale = Random.Range(spawnAsteroidsComponent.MINScale,
                        spawnAsteroidsComponent.MAXScale);

                    asteroidGO.transform.localScale = new Vector3(randomScale, randomScale);

                    EcsEntity asteroidEntity = asteroidGO.GetComponent<IEntityView>().Entity;

                    asteroidEntity.Del<PreDeathProgress>();

                    asteroidEntity.Get<DamageComponent>().Damage = _asteroidConfiguration.damage;

                    asteroidEntity.Get<RigidbodyComponent>().Rigidbody = asteroidGO.GetComponent<Rigidbody2D>();

                    asteroidEntity.Get<IncreaseGravitationComponent>().AddValue =
                        spawnAsteroidsComponent.AddValueIncreaseGravity;

                    asteroidEntity.Get<AsteroidTag>();

                    asteroidEntity.Get<AnimatorComponent>().Animator =
                        asteroidGO.GetComponentsInChildren<UnityEngine.Animator>()[0];

                    asteroidEntity.Get<ColliderComponent>().Collider = asteroidGO.GetComponent<Collider2D>();

                    asteroidEntity.Get<DeathHandlerComponent>().DeathHandler = _asteroidDeathHandler;

                    asteroidEntity.Get<HealthComponent>().Health = Random.Range(_asteroidConfiguration.minHealth,
                        _asteroidConfiguration.maxHealth);

                    asteroidEntity.Get<DamageableComponent>().Damageable = asteroidGO.GetComponent<IDamageable>();

                    asteroidEntity.Get<EnableColliderEvent>();
                }

                _filter.GetEntity(indexEntity).Get<SpawnAsteroidsBlockTimer>().Timer =
                    _asteroidConfiguration.spawnAsteroidsFrequency;
            }
        }
    }
}
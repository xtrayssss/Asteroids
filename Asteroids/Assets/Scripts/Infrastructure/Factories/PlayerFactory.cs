using Systems.InputSystems;
using Components.Animator;
using Components.Damage;
using Components.Destroy;
using Components.Health;
using Components.Move;
using Components.Projectile;
using Components.Tags;
using Configurations;
using HandlerInterfaces;
using Leopotam.Ecs;
using MonoBehaviours;
using MonoBehaviours.Views;
using Pool;
using UnityEngine;

namespace Infrastructure.Factories
{
    internal class PlayerFactory : IFactory
    {
        private readonly PlayerConfiguration _playerConfiguration;
        private readonly PoolObject _projectilePlayerPool;
        private readonly GameObject _gameOverMenuGO;
        private readonly ScreenPoints _screenPoints;

        public PlayerFactory(PlayerConfiguration playerConfiguration, GameObject poolContainer,
            GameObject gameOverMenuGO, ScreenPoints screenPoints)
        {
            _playerConfiguration = playerConfiguration;
            _gameOverMenuGO = gameOverMenuGO;
            _screenPoints = screenPoints;

            _projectilePlayerPool =
                new PoolObject(playerConfiguration.projectileConfiguration.prefabProjectile, 10,
                    true, poolContainer.transform);
        }

        public void CreateEntity(EcsWorld world)
        {
            EcsEntity entity = world.NewEntity();

            _playerConfiguration.CurrentEntity = entity;

            GameObject playerGO = Object.Instantiate(_playerConfiguration.playerPrefab);

            GameObject attackPointGO = Object.Instantiate(_playerConfiguration.attackPointPrefab, playerGO.transform);

            playerGO.GetComponent<PlayerView>().Init(entity);

            playerGO.transform.position =
                new Vector2(_screenPoints.CenterScreen.x, _screenPoints.ScreenLowestPoint.y) +
                _playerConfiguration.offsetSpawn;

            entity.Get<PlayerTag>();

            entity.Get<ModelComponent>().Transform = playerGO.transform;

            ref var speedComponent = ref entity.Get<SpeedComponent>();
            speedComponent.Speed = _playerConfiguration.speed;

            ref var rigidbodyComponent = ref entity.Get<RigidbodyComponent>();
            rigidbodyComponent.Rigidbody = playerGO.GetComponent<Rigidbody2D>();

            entity.Get<AttackInputComponent>();
            entity.Get<MovementDirectionComponent>();

            ref var spawnProjectileComponent = ref entity.Get<SpawnProjectileComponent>();
            spawnProjectileComponent.ProjectilesPool = _projectilePlayerPool;
            spawnProjectileComponent.Speed = _playerConfiguration.projectileConfiguration.speed;
            spawnProjectileComponent.Frequency = _playerConfiguration.projectileConfiguration.frequency;
            spawnProjectileComponent.SpawnPoint = attackPointGO.transform;
            spawnProjectileComponent.MovementDirection = Vector2.up;
            spawnProjectileComponent.Damage = _playerConfiguration.projectileConfiguration.damage;

            ref var projectileSpawnConditionComponent = ref entity.Get<ProjectileSpawnConditionComponent>();
            projectileSpawnConditionComponent.ConditionSpawnProjectile = new PlayerConditionConditionSpawnProjectile();

            ref var damageableComponent = ref entity.Get<DamageableComponent>();
            damageableComponent.Damageable = playerGO.GetComponent<IDamageable>();

            ref var healthComponent = ref entity.Get<HealthComponent>();
            healthComponent.Health = _playerConfiguration.health;
            healthComponent.MaxHealth = _playerConfiguration.health;

            ref var deathHandlerComponent = ref entity.Get<DeathHandlerComponent>();
            deathHandlerComponent.DeathHandler = new PlayerDeathHandler(_gameOverMenuGO, _playerConfiguration);

            ref var damageComponent = ref entity.Get<DamageComponent>();
            damageComponent.Damage = _playerConfiguration.bodyDamage;

            ref var animatorComponent = ref entity.Get<AnimatorComponent>();
            animatorComponent.Animator = playerGO.GetComponent<Animator>();
        }
    }
}
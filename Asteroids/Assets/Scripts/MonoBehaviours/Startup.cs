using Systems.Animator;
using Systems.Asteroids;
using Systems.Collider;
using Systems.Destroy;
using Systems.EnemyShip;
using Systems.Health;
using Systems.Init;
using Systems.InputSystems;
using Systems.Move;
using Systems.Projectile;
using Systems.Score;
using Components.Asteroids;
using Components.Bounds;
using Components.Collider;
using Components.EnemyShip;
using Components.Health;
using Components.Projectile;
using Components.Score;
using Configurations;
using Leopotam.Ecs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours
{
    public sealed class Startup : MonoBehaviour
    {
        [SerializeField] private GameConfigurations gameConfigurations;
        [SerializeField] private GameObject gameOverMenuGO;
        [SerializeField] private TMP_Text scoreText;

        private EcsWorld _world;
        private EcsSystems _initSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private ScreenPoints _screenPoints;
        private GameObject _poolContainer;
        private ApplicationHandler _applicationHandler;
        [SerializeField] private Image fillImage;

        private void Awake()
        {
            _screenPoints = FindObjectOfType<ScreenPoints>();
            _applicationHandler = FindObjectOfType<ApplicationHandler>();
        }

        private void Start()
        {
            CreatePoolContainer();

            _world = new EcsWorld();
            _applicationHandler.Init(_world);

            _initSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_initSystems);
#endif
            AddSystems();
            AddOneFrame();

            _initSystems.Init();
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }

        private void AddOneFrame()
        {
            _updateSystems
                .OneFrame<SpawnProjectileEvent>()
                .OneFrame<SpawnEnemyShipEvent>()
                .OneFrame<SpawnAsteroidsEvent>()
                .OneFrame<DisableColliderEvent>()
                .OneFrame<EnableColliderEvent>()
                .OneFrame<AddScoreEvent>()
                .OneFrame<HealthChangedEvent>();
        }

        private void AddSystems()
        {
            _initSystems
                .Add(new PlayerInitSystem(gameConfigurations.playerConfiguration, _poolContainer, gameOverMenuGO,
                    _screenPoints))
                .Add(new ScoreInitSystem(gameConfigurations.scoreConfiguration, scoreText))
                .Add(new SpawnerShipEnemyInitSystem(gameConfigurations.enemyShipConfiguration))
                .Add(new AsteroidsInitSystem(gameConfigurations.asteroidConfiguration, _poolContainer))
                .Add(new HealthBarInitSystem(fillImage, gameConfigurations.playerConfiguration));

            _updateSystems
                .Add(new PlayerInputSystem())
                .Add(new BlockMovementSystem(_screenPoints))
                .Add(new PlayerAnimationSystem())
                .Add(new ProjectileSetSpawnSystem())
                .Add(new CheckAliveEnemyShipSystem(gameConfigurations.enemyShipConfiguration))
                .Add(new SpawnEnemyShipTimerTickSystem())
                .Add(new EnemyShipSpawnSystem(gameConfigurations.enemyShipConfiguration, _screenPoints))
                .Add(new SpawnProjectileSystem(_poolContainer))
                .Add(new SpawnProjectileTimerTickSystem())
                .Add(new SwapDirectionSystem(_screenPoints))
                .Add(new SwapDirectionBlockTimerTickSystem())
                .Add(new SetSpawnAsteroidsSystem())
                .Add(new SpawnAsteroidsTimerTickSystem())
                .Add(new RecalculationBlockTimerTickSystem())
                .Add(new SpawnAsteroidsSystem(gameConfigurations.asteroidConfiguration, _screenPoints, _world))
                .Add(new EnableCollidersSystem())
                .Add(new IncreaseGravitationSystem())
                .Add(new IncreaseSpeedSystem())
                .Add(new BoundariesScreenSystem(_screenPoints))
                .Add(new ProjectileCollisionAnalyzeSystem())
                .Add(new HealthCheckerSystem())
                .Add(new HealthBarFillSystem())
                .Add(new AddScoreSystem())
                .Add(new AsteroidAnimationSystem())
                .Add(new DisableCollidersSystem())
                .Add(new DestroySystem());

            _fixedUpdateSystems
                .Add(new MoveSystem());
        }

        private void Update() =>
            _updateSystems?.Run();

        private void FixedUpdate() =>
            _fixedUpdateSystems?.Run();

        private void OnDestroy()
        {
            _initSystems.Destroy();
            _updateSystems.Destroy();
            _fixedUpdateSystems.Destroy();
            _world.Destroy();
        }

        private void CreatePoolContainer() =>
            _poolContainer = Instantiate(gameConfigurations.poolContainer);
    }
}
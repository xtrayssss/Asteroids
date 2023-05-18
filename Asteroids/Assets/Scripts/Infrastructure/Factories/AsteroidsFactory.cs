using System;
using System.Collections.Generic;
using Systems.Animator;
using Components.Animator;
using Components.Asteroids;
using Components.Bounds;
using Components.Move;
using Configurations;
using HandlerInterfaces;
using Leopotam.Ecs;
using MonoBehaviours.Views;
using Pool;
using UnityEngine;

namespace Infrastructure.Factories
{
    internal class AsteroidsFactory : IFactory
    {
        private const string FlamePath = "Flame/GFX";
        private readonly AsteroidConfiguration _asteroidConfiguration;
        private readonly PoolObject _asteroidsPool;

        public AsteroidsFactory(AsteroidConfiguration asteroidConfiguration, GameObject poolContainer)
        {
            _asteroidConfiguration = asteroidConfiguration;
            _asteroidsPool =
                new PoolObject(asteroidConfiguration.asteroidPrefab, asteroidConfiguration.maxAmountSpawnAsteroids, true,
                    poolContainer.transform);
        }

        public void CreateEntity(EcsWorld world)
        {
            List<GameObject> asteroidsList = _asteroidsPool.GetPoolList();

            ICanBeyondBorders asteroidsBeyondBorders = new AsteroidsBeyondBorders();

            EcsEntity spawnerEntity = world.NewEntity();

            foreach (GameObject asteroidGO in asteroidsList)
            {
                EcsEntity asteroidEntity = world.NewEntity();
                AsteroidView asteroidView = asteroidGO.GetComponent<AsteroidView>();
                asteroidView.Init(asteroidEntity);
                asteroidView.Entity.Get<ModelComponent>().Transform = asteroidGO.transform;
                asteroidView.Entity.Get<CanBeyondBordersComponent>().CanBeyondBorders = asteroidsBeyondBorders;
                
                EcsEntity flameEntity = world.NewEntity();

                flameEntity.Get<AnimatorComponent>().Animator = asteroidEntity.Get<ModelComponent>()
                    .Transform.Find(FlamePath).GetComponent<Animator>();

                asteroidEntity.Get<AttachedEntityComponent>().Entity = flameEntity;
            }

            spawnerEntity.Get<SpawnAsteroidsEvent>();

            ref var spawnAsteroidsComponent = ref spawnerEntity.Get<SpawnAsteroidsComponent>();
            spawnAsteroidsComponent.PoolAsteroids = _asteroidsPool;
            spawnAsteroidsComponent.MINSpawnAmountAsteroids = _asteroidConfiguration.minAmountSpawnAsteroids;
            spawnAsteroidsComponent.MAXAmountAsteroidsSpawn = _asteroidConfiguration.maxAmountSpawnAsteroids;
            spawnAsteroidsComponent.AddValueIncreaseGravity = _asteroidConfiguration.addValueIncreaseGravity;
            spawnAsteroidsComponent.MINScale = _asteroidConfiguration.minScale;
            spawnAsteroidsComponent.MAXScale = _asteroidConfiguration.maxScale;
        }
    }
}
using Components.Asteroids;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Asteroids
{
    internal class SpawnAsteroidsTimerTickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnAsteroidsBlockTimer> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var spawnAsteroidsBlockTimer = ref _filter.Get1(indexEntity);

                spawnAsteroidsBlockTimer.Timer -= Time.deltaTime;

                if (spawnAsteroidsBlockTimer.Timer <= 0.0f)
                {
                    _filter.GetEntity(indexEntity).Del<SpawnAsteroidsBlockTimer>();
                    _filter.GetEntity(indexEntity).Get<SpawnAsteroidsEvent>();
                }
            }
        }
    }
}
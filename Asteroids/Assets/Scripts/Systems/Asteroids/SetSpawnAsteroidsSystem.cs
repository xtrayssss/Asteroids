using Components.Asteroids;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Asteroids
{
    internal class SetSpawnAsteroidsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnAsteroidsBlockTimer> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var spawnAsteroidsBlockTimer = ref _filter.Get1(indexEntity);

                if (spawnAsteroidsBlockTimer.Timer <= 0.0f)
                {
                    ref var entity = ref _filter.GetEntity(indexEntity);

                    entity.Get<SpawnAsteroidsEvent>();

                    entity.Del<SpawnAsteroidsBlockTimer>();
                }
            }
        }
    }
}
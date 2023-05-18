using Components.Projectile;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Projectile
{
    internal class SpawnProjectileTimerTickSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnProjectileBlockTimer> _filter;
        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var spawnProjectileBlockTimer = ref _filter.Get1(indexEntity);

                spawnProjectileBlockTimer.Timer -= Time.deltaTime;

                if (spawnProjectileBlockTimer.Timer <= 0.0f)
                {
                    ref var entity = ref _filter.GetEntity(indexEntity);
                    
                    entity.Del<SpawnProjectileBlockTimer>();
                }
            }
        }
    }
}
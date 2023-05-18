using Components.Projectile;
using Leopotam.Ecs;

namespace Systems.Projectile
{
    internal class ProjectileSetSpawnSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ProjectileSpawnConditionComponent> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var projectileSpawnConditionComponent = ref _filter.Get1(indexEntity);

                ref var entity = ref _filter.GetEntity(indexEntity);

                if (projectileSpawnConditionComponent.ConditionSpawnProjectile != null &&
                    projectileSpawnConditionComponent.ConditionSpawnProjectile.CheckConditionFulfillment(entity))
                {
                    entity.Get<SpawnProjectileEvent>();
                }
            }
        }
    }
}
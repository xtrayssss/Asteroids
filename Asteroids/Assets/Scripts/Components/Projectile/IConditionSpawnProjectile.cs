using Leopotam.Ecs;

namespace Components.Projectile
{
    internal interface IConditionSpawnProjectile
    {
        public bool CheckConditionFulfillment(EcsEntity entity);
    }
}
using Components.Projectile;
using Leopotam.Ecs;

namespace HandlerInterfaces
{
    internal class EnemyShipSpawnProjectileCondition : IConditionSpawnProjectile
    {
        public bool CheckConditionFulfillment(EcsEntity entity)
        {
            if (entity.Get<SpawnProjectileBlockTimer>().Timer <= 0.0f)
            {
                entity.Del<SpawnProjectileBlockTimer>();

                return true;
            }

            return false;
        }
    }
}
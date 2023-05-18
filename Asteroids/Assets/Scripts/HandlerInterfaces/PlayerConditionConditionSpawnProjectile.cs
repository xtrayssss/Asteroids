using Systems.InputSystems;
using Components.Projectile;
using Leopotam.Ecs;

namespace HandlerInterfaces
{
    internal class PlayerConditionConditionSpawnProjectile : IConditionSpawnProjectile
    {
        public bool CheckConditionFulfillment(EcsEntity entity) => 
            entity.Get<AttackInputComponent>().Attack;
    }
}
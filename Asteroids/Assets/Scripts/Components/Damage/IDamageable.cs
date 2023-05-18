using Leopotam.Ecs;

namespace Components.Damage
{
    internal interface IDamageable
    {
        public void TakeDamage(EcsEntity entity, float damage);
    }
}
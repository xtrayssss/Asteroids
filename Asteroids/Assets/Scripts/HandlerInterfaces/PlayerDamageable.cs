using Components.Damage;
using Components.Health;
using Leopotam.Ecs;
using UnityEngine;

namespace HandlerInterfaces
{
    internal class PlayerDamageable : MonoBehaviour, IDamageable
    {
        public void TakeDamage(EcsEntity entity, float damage)
        {
            ref var healthComponent = ref entity.Get<HealthComponent>();
            healthComponent.Health -= damage;
            entity.Get<HealthChangedEvent>();

            ref EcsEntity hpBarEntity = ref entity.Get<HealthBarAttachedComponent>().HpBarEntity;
            
            hpBarEntity.Get<HealthBarComponent>().TargetValue =
                healthComponent.Health / healthComponent.MaxHealth;
            
            hpBarEntity.Get<StartFillProgress>();
        }
    }
}
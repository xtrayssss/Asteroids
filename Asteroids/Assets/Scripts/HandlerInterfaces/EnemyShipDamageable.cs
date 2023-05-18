using Components.Damage;
using Components.Health;
using Leopotam.Ecs;
using UnityEngine;

namespace HandlerInterfaces
{
    public class EnemyShipDamageable : MonoBehaviour, IDamageable 
    {
        public void TakeDamage(EcsEntity entity, float damage)
        {
            entity.Get<HealthComponent>().Health -= damage;
            entity.Get<HealthChangedEvent>();
        }
    }
}
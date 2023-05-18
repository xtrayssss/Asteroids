using Components.Damage;
using Components.Projectile;
using Leopotam.Ecs;
using MonoBehaviours.Views;
using UnityEngine;

namespace MonoBehaviours.Collision
{
    public class AsteroidCollision : MonoBehaviour
    {
        private IEntityView _asteroidView;

        private void Start() =>
            _asteroidView = GetComponentInParent<IEntityView>();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerView playerView))
            {
                playerView.Entity.Get<DamageableComponent>().Damageable.TakeDamage(playerView.Entity,
                    _asteroidView.Entity.Get<DamageComponent>().Damage);

                _asteroidView.Entity.Get<DamageableComponent>().Damageable.TakeDamage(_asteroidView.Entity,
                    playerView.Entity.Get<DamageComponent>().Damage);
            }
        }
    }
}
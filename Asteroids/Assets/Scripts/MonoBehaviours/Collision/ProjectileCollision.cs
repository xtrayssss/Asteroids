using Components.Damage;
using Components.Triggers;
using Extensions;
using Leopotam.Ecs;
using MonoBehaviours.Views;
using UnityEngine;

namespace MonoBehaviours.Collision
{
    public class ProjectileCollision : MonoBehaviour
    {
        private IEntityView _projectileEntityView;

        private EcsWorld _world;

        private void Start() =>
            _projectileEntityView = GetComponent<IEntityView>();

        public void InitWorld(EcsWorld world) =>
            _world = world;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamageable _))
            {
                _world.CreateNewEntity(new OnTriggerEnterComponent()
                {
                    Other = other,
                    ThisEntity = _projectileEntityView.Entity,
                    ThisGO = gameObject
                });
            }
        }
    }
}
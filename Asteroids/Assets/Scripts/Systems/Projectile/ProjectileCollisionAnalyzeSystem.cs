using Components.Damage;
using Components.Destroy;
using Components.Projectile;
using Components.Tags;
using Components.Triggers;
using Leopotam.Ecs;
using MonoBehaviours.Views;

namespace Systems.Projectile
{
    internal class ProjectileCollisionAnalyzeSystem : IEcsRunSystem
    {
        private readonly EcsFilter<OnTriggerEnterComponent> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var onTriggerEnterComponent = ref _filter.Get1(indexEntity);

                EcsEntity projectileEntity = onTriggerEnterComponent.ThisEntity;

                if (!projectileEntity.IsAlive())
                {
                    DestroyCurrentEntity(indexEntity);
                    continue;
                }

                EcsEntity senderEntity = projectileEntity.Get<SenderProjectileComponent>().Entity;

                if (!senderEntity.IsAlive())
                {
                    DestroyCurrentEntity(indexEntity);
                    continue;
                }

                EcsEntity otherEntity = onTriggerEnterComponent.Other.GetComponent<IEntityView>().Entity;

                if (!otherEntity.IsAlive())
                {
                    DestroyCurrentEntity(indexEntity);
                    continue;
                }


                if (senderEntity.Has<EnemyTag>() &&
                    !otherEntity.Has<PlayerTag>())
                {
                    DestroyCurrentEntity(indexEntity);
                    continue;
                }


                onTriggerEnterComponent.Other.GetComponent<IDamageable>().TakeDamage(otherEntity,
                    onTriggerEnterComponent.ThisEntity.Get<DamageComponent>().Damage);

                onTriggerEnterComponent.ThisGO.SetActive(false);

                projectileEntity.Get<DestroyEvent>();

                DestroyCurrentEntity(indexEntity);
            }
        }

        private void DestroyCurrentEntity(int indexEntity)
        {
            _filter.GetEntity(indexEntity).Get<DestroyEvent>();
        }
    }
}
using Components.Bounds;
using Components.Damage;
using Components.Move;
using Components.Projectile;
using HandlerInterfaces;
using Leopotam.Ecs;
using MonoBehaviours.Collision;
using MonoBehaviours.Views;
using UnityEngine;

namespace Systems.Projectile
{
    internal class SpawnProjectileSystem : IEcsRunSystem
    {
        private readonly GameObject _containerPool;

        private readonly EcsFilter<SpawnProjectileEvent, SpawnProjectileComponent>.Exclude<SpawnProjectileBlockTimer>
            _filter;

        private readonly EcsWorld _world;

        private readonly ICanBeyondBorders _projectileBeyondBorders = new ProjectileBeyondBorders();

        public SpawnProjectileSystem(GameObject containerPool) =>
            _containerPool = containerPool;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                GameObject projectileGO;

                ref var spawnProjectileComponent = ref _filter.Get2(indexEntity);

                if (spawnProjectileComponent.ProjectilesPool != null)
                {
                    projectileGO = spawnProjectileComponent.ProjectilesPool.GetFreeObject();
                }
                else
                {
                    projectileGO = Object.Instantiate(spawnProjectileComponent.PrefabProjectile,
                        _containerPool.transform);
                }

                projectileGO.transform.position = spawnProjectileComponent.SpawnPoint.position;

                EcsEntity projectileEntity = _world.NewEntity();

                projectileGO.GetComponent<ProjectileView>().Init(projectileEntity);

                projectileEntity.Get<RigidbodyComponent>().Rigidbody = projectileGO.GetComponent<Rigidbody2D>();

                projectileEntity.Get<MovementDirectionComponent>().Direction =
                    spawnProjectileComponent.MovementDirection;

                projectileEntity.Get<SpeedComponent>().Speed = spawnProjectileComponent.Speed;

                projectileEntity.Get<DamageComponent>().Damage = spawnProjectileComponent.Damage;

                projectileEntity.Get<ModelComponent>().Transform = projectileGO.transform;

                EcsEntity spawnerEntity = _filter.GetEntity(indexEntity);

                spawnerEntity.Get<SpawnProjectileBlockTimer>().Timer =
                    spawnProjectileComponent.Frequency;

                projectileEntity.Get<CanBeyondBordersComponent>().CanBeyondBorders = _projectileBeyondBorders;

                projectileEntity.Get<SenderProjectileComponent>().Entity = spawnerEntity;

                projectileGO.GetComponent<ProjectileCollision>().InitWorld(_world);

                if (spawnerEntity.Has<IncreaseSpeedProjectile>())
                {
                    ref var increaseSpeedComponent = ref projectileEntity.Get<IncreaseSpeedComponent>();
                    increaseSpeedComponent.AddValue = spawnProjectileComponent.ProjectileIncreaseSpeedAddValue;
                    increaseSpeedComponent.Multiplier = spawnProjectileComponent.ProjectileIncreaseSpeedMultiplier;
                }
            }
        }
    }
}
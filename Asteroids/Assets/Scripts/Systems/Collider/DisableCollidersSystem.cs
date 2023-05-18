using Systems.Destroy;
using Components.Collider;
using Leopotam.Ecs;

namespace Systems.Collider
{
    internal class DisableCollidersSystem : IEcsRunSystem
    {
        private EcsFilter<DisableColliderEvent, ColliderComponent> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var entity = ref _filter.GetEntity(indexEntity);
                entity.Get<ColliderComponent>().Collider.enabled = false;
            }
        }
    }
}
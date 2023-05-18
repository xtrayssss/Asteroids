using Components.Destroy;
using Leopotam.Ecs;

namespace Systems.Destroy
{
    internal class DestroySystem : IEcsRunSystem
    {
        private readonly EcsFilter<DestroyEvent> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var entity = ref _filter.GetEntity(indexEntity);
                entity.Destroy();
            }
        }
    }
}
using Components.Move;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Move
{
    internal class IncreaseGravitationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RigidbodyComponent, IncreaseGravitationComponent> _filter;

        public void Run()
        {
            foreach (var indexEntity in _filter)
            {
                ref var rigidbodyComponent = ref _filter.Get1(indexEntity);
                ref var increaseGravitationComponent = ref _filter.Get2(indexEntity);

                rigidbodyComponent.Rigidbody.gravityScale = increaseGravitationComponent.AddValue += Time.deltaTime;
            }
        }
    }
}
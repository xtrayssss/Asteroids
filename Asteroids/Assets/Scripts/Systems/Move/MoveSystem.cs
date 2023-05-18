using Systems.Animator;
using Components.Move;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Move
{
    internal class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpeedComponent, RigidbodyComponent, MovementDirectionComponent>
            _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var speedComponent = ref _filter.Get1(indexEntity);
                ref var rigidbodyComponent = ref _filter.Get2(indexEntity);
                ref var movementDirectionComponent = ref _filter.Get3(indexEntity);

                rigidbodyComponent.Rigidbody.MovePosition((Vector2) rigidbodyComponent.Rigidbody.transform.position +
                                                          movementDirectionComponent.Direction *
                                                          (speedComponent.Speed * Time.deltaTime));
            }
        }
    }
}
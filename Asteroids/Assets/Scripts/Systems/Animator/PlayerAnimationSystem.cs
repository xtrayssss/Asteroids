using Components.Animator;
using Components.Move;
using Components.Tags;
using Leopotam.Ecs;

namespace Systems.Animator
{
    internal class PlayerAnimationSystem : IEcsRunSystem
    {
        private static readonly int X = UnityEngine.Animator.StringToHash("X");

        private readonly EcsFilter<PlayerTag, AnimatorComponent> _filter;

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var animatorComponent = ref _filter.Get2(indexEntity);

                ref var entity = ref _filter.GetEntity(indexEntity);

                animatorComponent.Animator.SetFloat(X, entity.Get<MovementDirectionComponent>().Direction.x);
            }
        }
    }
}
using Components.Animator;
using Components.Destroy;
using Components.Move;
using Components.Tags;
using Leopotam.Ecs;

namespace Systems.Animator
{
    internal class AsteroidAnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AsteroidTag, AnimatorComponent> _filter;
        private readonly EcsWorld _world;

        private static readonly int Flame = UnityEngine.Animator.StringToHash("Flame");
        private static readonly int Death = UnityEngine.Animator.StringToHash("Death");

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var animatorComponent = ref _filter.Get2(indexEntity);
                ref var entity = ref _filter.GetEntity(indexEntity);

                animatorComponent.Animator.SetBool(Death, entity.Has<PreDeathProgress>());

                ref var attachedEntityComponent = ref entity.Get<AttachedEntityComponent>();
                ref var flameAnimatorComponent = ref attachedEntityComponent.Entity.Get<AnimatorComponent>();

                flameAnimatorComponent.Animator.SetBool(Flame,
                    entity.Get<RigidbodyComponent>().Rigidbody.velocity.y <= -7.0f && !entity.Has<PreDeathProgress>());
            }
        }
    }

    internal struct AttachedEntityComponent
    {
        public EcsEntity Entity;
    }
}
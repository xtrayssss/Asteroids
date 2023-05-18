using Components.Move;
using Components.Tags;
using Leopotam.Ecs;
using MonoBehaviours;
using UnityEngine;

namespace Systems.InputSystems
{
    internal class PlayerInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<PlayerTag, MovementDirectionComponent, AttackInputComponent> _filter;
        private PlayerInputHandler _playerInputHandler;

        public void Init() => 
            _playerInputHandler = Object.FindObjectOfType<PlayerInputHandler>();

        public void Run()
        {
            foreach (int indexEntity in _filter)
            {
                ref var movementDirectionComponent = ref _filter.Get2(indexEntity);
                ref var attackInputComponent = ref _filter.Get3(indexEntity);

                movementDirectionComponent.Direction = _playerInputHandler.MoveDirection;
                attackInputComponent.Attack = _playerInputHandler.IsAttack;
            }
        }
    }

    internal struct AttackInputComponent
    {
        public bool Attack;
    }
}
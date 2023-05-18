using UnityEngine;
using UnityEngine.InputSystem;

namespace MonoBehaviours
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 MoveDirection { get; private set; }
        public bool IsAttack { get; private set; }

        public void Move(InputAction.CallbackContext callbackContext) =>
            MoveDirection = callbackContext.ReadValue<Vector2>();

        public void Attack(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.performed)
            {
                IsAttack = true;
            }

            if (callbackContext.canceled)
            {
                IsAttack = false;
            }
        }
    }
}
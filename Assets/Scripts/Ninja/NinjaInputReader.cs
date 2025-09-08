using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class NinjaInputReader : MonoBehaviour
{
    public float MoveDirection { get; private set; }
    public bool Jump { get; private set; }
    public bool Attack { get; private set; }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump = true;
        }
        if (context.canceled)
        {
            Jump = false;
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<float>();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Attack = true;
        }
    }
}

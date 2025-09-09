using System.Collections;
using UnityEngine;

namespace Ninja.FSM
{
    public class JumpState : NinjaState
    {

        float maxGravity = 10.0f;
        float baseGravity = 1.0f;
        bool isJumpingUp = false;
        public JumpState(NinjaController ninjaController) : base(ninjaController) { }
        public override void Enter()
        {
            ninjaController.animator.SetBool("isJumping", true);
            ninjaController.Jump();
            isJumpingUp = true;
        }

        public override void Update()
        {
            if (!ninjaController.ninjaInputReader.Jump && isJumpingUp)
            {
                float xVelocity = ninjaController.getRBVelocity().x;
                ninjaController.setRBVelocity(new Vector2(xVelocity, 0));
                isJumpingUp = false;
            }
            if (ninjaController.getRBVelocity().y <= 0 && ninjaController.CheckGrounded())
            {
                ninjaController.ChangeState(NinjaController.State.idleState);
                return;
            }
            if (ninjaController.getRBVelocity().y < 0)
            {
                float gravity = Mathf.Min(ninjaController.getGravity() * 1.5f, maxGravity);
                ninjaController.setGravity(gravity);
            }

            ninjaController.Move(ninjaController.ninjaInputReader.MoveDirection);
            ninjaController.Flip(ninjaController.ninjaInputReader.MoveDirection);

            float yVelocity = ninjaController.getRBVelocity().y;
            ninjaController.animator.SetFloat("yVelocity", yVelocity);
        }

        public override void Exit()
        {
            ninjaController.animator.SetBool("isJumping", false);
            ninjaController.setGravity(baseGravity);
        }
    }
}

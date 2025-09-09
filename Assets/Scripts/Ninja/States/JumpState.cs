using UnityEngine;

namespace Ninja.FSM
{
    public class JumpState : NinjaState
    {
        private bool isJumping = false;

        public JumpState(NinjaController ninjaController) : base(ninjaController) { }
        public override void Enter()
        {
            ninjaController.animator.SetBool("isJumping", true);
            ninjaController.Jump();
        }

        public override void Execute()
        {
            // set isJumping when the character off the Ground
            if (!isJumping && !ninjaController.CheckGrounded())
            {
                isJumping = true;
            }
            if (!isJumping) return;

            if (ninjaController.CheckGrounded())
            {
                ninjaController.ChangeState(NinjaController.State.idleState);
            }

            ninjaController.Move(ninjaController.ninjaInputReader.MoveDirection);
            ninjaController.Flip(ninjaController.ninjaInputReader.MoveDirection);

            float yVelocity = ninjaController.getRBVelocity().y;
            ninjaController.animator.SetFloat("yVelocity", yVelocity); 
        }

        public override void Exit()
        {
            ninjaController.animator.SetBool("isJumping", false);
            isJumping = false;
        }
    }
}

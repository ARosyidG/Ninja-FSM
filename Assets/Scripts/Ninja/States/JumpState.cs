using UnityEngine;

namespace Ninja.FSM
{
    public class JumpState : NinjaState
    {
        public JumpState(NinjaController ninjaController) : base(ninjaController) { }
        public override void Enter()
        {
            ninjaController.animator.SetBool("isJumping", true);
            ninjaController.Jump();
        }

        public override void Update()
        {
            if (ninjaController.getRBVelocity().y <= 0 && ninjaController.CheckGrounded())
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
        }
    }
}

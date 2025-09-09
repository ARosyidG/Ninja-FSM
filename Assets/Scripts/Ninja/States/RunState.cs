using UnityEngine;

namespace Ninja.FSM
{
    public class RunState : NinjaState
    {
        public RunState(NinjaController ninjaController) : base(ninjaController){}

        public override void Enter()
        {
            ninjaController.animator.SetFloat("xVelocity", 1);
        }

        public override void Update()
        {
            float moveDirection = ninjaController.ninjaInputReader.MoveDirection;
            if (moveDirection == 0.0f)
            {
                ninjaController.ChangeState(NinjaController.State.idleState);
            }
            if (ninjaController.ninjaInputReader.Jump)
            {
                ninjaController.ChangeState(NinjaController.State.jumpState);
            }
            if (ninjaController.ninjaInputReader.Attack)
            {
                ninjaController.ChangeState(NinjaController.State.attackState);
                return;
            }
            ninjaController.Move(moveDirection);
            ninjaController.Flip(moveDirection);
        }

        public override void Exit()
        {
            ninjaController.animator.SetFloat("xVelocity", 0);
        }
    }
}

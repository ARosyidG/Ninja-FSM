using UnityEngine;

namespace Ninja.FSM
{
    public class IdleState : NinjaState
    {
        public IdleState(NinjaController ninjaController) : base(ninjaController){}

        public override void Enter()
        {
            Debug.Log("enter Idle State");
        }

        public override void Execute()
        {
            if (ninjaController.ninjaInputReader.MoveDirection != 0.0f)
            {
                ninjaController.ChangeState(NinjaController.State.runState);
            }
            if (ninjaController.ninjaInputReader.Jump && ninjaController.CheckGrounded())
            {
                ninjaController.ChangeState(NinjaController.State.jumpState);
            }
            if (ninjaController.ninjaInputReader.Attack)
            {
                ninjaController.ChangeState(NinjaController.State.attackState);
            }
        }

        public override void Exit(){}
    }
}

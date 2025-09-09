
using UnityEngine;
namespace Ninja.FSM
{
    public class AttackState : NinjaState
    {
        public AttackState(NinjaController ninjaController) : base(ninjaController){}

        public override void Enter()
        {
            ninjaController.animator.SetTrigger("Attack");
            ninjaController.Move(0f);
        }

        public override void Update()
        {
            if (ninjaController.isPlaying("Attack")) return;
            if (ninjaController.ninjaInputReader.MoveDirection == 0.0f)
            {
                ninjaController.ChangeState(NinjaController.State.idleState);
            }
            else
            {
                ninjaController.ChangeState(NinjaController.State.runState);
            }
        }

        public override void Exit(){}
    }
}
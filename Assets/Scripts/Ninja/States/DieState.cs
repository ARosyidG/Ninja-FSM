using UnityEngine;
namespace Ninja.FSM
{
    public class DieState : NinjaState
    {
        public DieState(NinjaController ninjaController) : base(ninjaController){}

        public override void Enter()
        {
            ninjaController.animator.SetTrigger("Die");
        }

        public override void Update()
        {
            // Logic for when the ninja is dead (e.g., play death animation)
        }

        public override void Exit()
        {
            // Logic for exiting the die state, if applicable
        }
    }
}
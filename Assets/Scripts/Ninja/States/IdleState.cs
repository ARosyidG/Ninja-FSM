using UnityEngine;

namespace Ninja.FSM
{
    public class IdleState : NinjaState
    {
        public IdleState(NinjaController ninjaController) : base(ninjaController){}

        public override void Enter()
        {
            Debug.Log("Ninja is idling.");
        }

        public override void Execute()
        {
            // if (ninjaController.)
        }

        public override void Exit()
        {
            // Logic for exiting the hurt state, if applicable
        }
    }
}

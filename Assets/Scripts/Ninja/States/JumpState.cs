using UnityEngine;

namespace Ninja.FSM
{
    public class JumpState : NinjaState
    {
        public override void Enter()
        {
            Debug.Log("Ninja is Jumping.");
        }

        public override void Execute()
        {
            // Logic for when the ninja is hurt (e.g., play hurt animation)
        }

        public override void Exit()
        {
            // Logic for exiting the hurt state, if applicable
        }
    }
}

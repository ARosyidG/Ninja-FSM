using UnityEngine;

namespace Ninja.FSM
{
    public class RunState : NinjaState
    {
        public override void Enter()
        {
            Debug.Log("Ninja is Running.");
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

using UnityEngine;
namespace Ninja.FSM
{
    public class DieState : NinjaState
    {
        public override void Enter()
        {
            Debug.Log("Ninja has died.");
        }

        public override void Execute()
        {
            // Logic for when the ninja is dead (e.g., play death animation)
        }

        public override void Exit()
        {
            // Logic for exiting the die state, if applicable
        }
    }
}
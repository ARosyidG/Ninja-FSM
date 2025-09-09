using UnityEngine;
namespace Ninja.FSM
{
    public class HurtState : NinjaState
    {
        public HurtState(NinjaController ninjaController) : base(ninjaController){}

        public override void Enter()
        {
            Debug.Log("Ninja is hurt.");
        }

        public override void Update()
        {
            // Logic for when the ninja is hurt (e.g., play hurt animation)
        }

        public override void Exit()
        {
            // Logic for exiting the hurt state, if applicable
        }
    }
}
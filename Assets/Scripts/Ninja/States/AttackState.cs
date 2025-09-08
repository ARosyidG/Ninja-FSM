
using UnityEngine;
namespace Ninja.FSM
{
    public class AttackState : NinjaState
    {
        public AttackState(NinjaController ninjaController) : base(ninjaController){}

        public override void Enter()
        {
            Debug.Log("Ninja is attacking.");
        }

        public override void Execute()
        {
            // Logic for when the ninja is attacking (e.g., play attack animation)
        }

        public override void Exit()
        {
            // Logic for exiting the attack state, if applicable
        }
    }
}
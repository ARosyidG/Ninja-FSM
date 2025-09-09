using UnityEngine;
namespace Ninja.FSM
{
    public class HurtState : NinjaState
    {
        private float timer;
        private Vector2 direction;
        public HurtState(NinjaController ninjaController) : base(ninjaController) { }

        public override void Enter()
        {
            ninjaController.animator.SetBool("isHurt", true);
            timer = ninjaController.knockbackDuration;
            ninjaController.Knockback();
        }

        public override void Update()
        {
            timer -= Time.deltaTime;
            if (timer > 0) return;
            ninjaController.ChangeState(NinjaController.State.jumpState);
        }

        public override void Exit()
        {
            ninjaController.animator.SetBool("isHurt", false);
        }
    }
}
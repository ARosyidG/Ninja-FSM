using Ninja.FSM;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    NinjaState currentState;
    IdleState idleState = new IdleState();
    AttackState attackState = new AttackState();
    HurtState hurtState = new HurtState();
    RunState runState = new RunState();
    JumpState jumpState = new JumpState();
    DieState dieState = new DieState();

}

using UnityEngine;

public abstract class NinjaState : IState
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}

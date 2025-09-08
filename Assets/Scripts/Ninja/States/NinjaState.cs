using UnityEngine;

public abstract class NinjaState : IState
{
    protected NinjaController ninjaController;

    public NinjaState(NinjaController ninjaController)
    {
        this.ninjaController = ninjaController;
    }
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}

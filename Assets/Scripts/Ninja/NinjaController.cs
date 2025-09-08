using System;
using System.Collections.Generic;
using Ninja.FSM;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private NinjaState currentState;
    private Dictionary<State, NinjaState> stateMap;
    public enum State
    {
        idleState,
        attackState,
        hurtState,
        runState,
        jumpState,
        dieState
    }
    public State CurrentState
    {
        get { return CurrentState; }
        private set
        {
            CurrentState = value;
            currentState = stateMap[value];
        }
    }    
void Awake()
    {
        stateMap = new Dictionary<State, NinjaState>()
        {
            { State.idleState, new IdleState(this) },
            { State.attackState, new AttackState(this) },
            { State.hurtState, new HurtState(this) },
            { State.runState, new RunState(this) },
            { State.jumpState, new JumpState(this) },
            { State.dieState, new DieState(this) }
        };
    }

    void Start()
    {
        changeState(State.idleState);
    }

    void changeState(State newState)
    {
        if (newState == CurrentState) return;
        if (!stateMap.ContainsKey(newState))
        {
            Debug.LogError($"State {newState} not found in state map!");
            return;
        }
        currentState?.Exit();
        CurrentState = newState;
        currentState.Enter();
    }
}

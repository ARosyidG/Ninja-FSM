using System;
using System.Collections.Generic;
using Ninja.FSM;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class NinjaController : MonoBehaviour, IDamageable
{
    private NinjaState currentState;
    private Dictionary<State, NinjaState> stateMap;
    private State _currentStateEnum;
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
        get { return _currentStateEnum; }
        private set
        {
            _currentStateEnum = value;
            currentState = stateMap[value];
        }
    }
    public Animator animator;
    public NinjaInputReader ninjaInputReader;

    public bool IsDead { get; private set; }

    [Header("Health")]
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float currentHealth;
    [SerializeField] private HealthBar healthBar;

    [Header("Movement")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 10;


    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Header("Knockback Settings")]
    public float knockbackForce = 100f;
    public float knockbackDuration = 1f;
    public Vector2 knockbackDirection;

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
        // ChangeState(State.idleState);
        CurrentState = State.idleState;
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }
    void Update()
    {
        currentState?.Update();
        // Debug.Log($"velocity {rb.linearVelocity}");
        // Debug.Log(CheckGrounded());
    }

    public void ChangeState(State newState)
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
        Debug.Log($"state change {newState}");
    }
    public void Move(float direction)
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
    }
    public void Flip(float direction)
    {
        if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }
    public bool CheckGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public Vector2 getRBVelocity()
    {
        return rb.linearVelocity;
    }
    public void setRBVelocity(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
    }

    public bool isPlaying(String stateName)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    public void TakeDamage(int amount, GameObject from)
    {
        if (IsDead) return;

        setHealth(currentHealth - amount);

        knockbackDirection = (transform.position - from.transform.position).normalized;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            ChangeState(State.dieState);
        }
        else
        {
            ChangeState(State.hurtState);
        }
    }
    private void setHealth(float value)
    {
        currentHealth = value;
        healthBar.setHealth(currentHealth);
    }
    public void Knockback()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(knockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
    }

    public float getGravity()
    {
        return rb.gravityScale;
    }
    public void setGravity(float gravity)
    {
        rb.gravityScale = gravity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public PlayerInputHandler playerInput;

    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }

    public CharacterController controller;
    public Core core;


    public bool isGrounded;
    [SerializeField]
    private PlayerData playerData;

    [Header("Gravity")]
    public float gravity = 10;
    public float currentGravity;
    public float constantGravity;
    public float maxGravity;

    //Movement
    public Vector2 input_Movement;
    public Vector2 input_View;



    private Vector3 gravityDirection;
    public Vector3 gravityMovement;

    public Animator Anim;
    protected override void Awake()
    {
        base.Awake();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        WalkState = new PlayerWalkState(this, StateMachine, playerData, "walk");
        RunState = new PlayerRunState(this, StateMachine, playerData, "run");

        gravityDirection = Vector3.down;
    }
    private  void Start()
    {
        StateMachine.Initialize(IdleState);
        
        
    }
    private void Update()
    {
        CalculateGravity();
        isGrounded = core.collisionSenses.Ground;

        controller.Move(gravityMovement);
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        
    }
    
    //=====Gravity=========
    private void CalculateGravity()
    {
        if (isGrounded)
        {
            currentGravity = constantGravity;
        }
        else
        {
            if (currentGravity > maxGravity)
            {
                currentGravity -= gravity * Time.deltaTime;
            }
        }
        gravityMovement = gravityDirection * -currentGravity * Time.deltaTime;

    }

}


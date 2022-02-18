using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public PlayerInputHandler playerInput;

    public PlayerStateMachine StateMachine { get; private set; }

    public CharacterController controller;
    public Core core;

    public bool isGrounded;
    [SerializeField]
    private PlayerData playerData;

    [Header("Gravity")]
    public float gravity;
    public float currentGravity;
    public float constantGravity;
    public float maxGravity;

    //Movement
    public Vector2 input_Movement;
    public Vector2 input_View;



    private Vector3 gravityDirection;
    private Vector3 gravityMovement;

    public Animator Anim { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        //
        //playerInput = new PlayerInputAction();

        //playerInput.Movement.Movement.performed += x => input_Movement = x.ReadValue<Vector2>();




        StateMachine = new PlayerStateMachine();
        gravityDirection = Vector3.down;
    }
    private  void Start()
    {
        Anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        CalculateGravity();
        isGrounded = core.collisionSenses.Ground;
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


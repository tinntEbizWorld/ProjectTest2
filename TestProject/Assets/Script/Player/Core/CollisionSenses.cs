using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSenses : CoreComponent
{
    public Transform GroundCheck
    {
        get => GenericNotImplementedError<Transform>.TryGet(groundCheck, core.transform.parent.name);
        private set => groundCheck = value;
    }
    public float GroundCheckRadius { get => groundCheckDistance; set => groundCheckDistance = value; }
    public LayerMask WhatIsGround { get => whatIsGround; set => whatIsGround = value; }
    [SerializeField]
    private Transform groundCheck;

    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    public bool Ground
    {
        get => Physics.Raycast(GroundCheck.position, Vector3.down,groundCheckDistance, whatIsGround);
    }
}

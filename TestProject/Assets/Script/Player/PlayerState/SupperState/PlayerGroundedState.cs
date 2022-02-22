using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    protected int zInput;

    private bool isGrounded;
    protected bool jumpInput;
    protected bool runInput;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.controller.isGrounded;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.playerInput.NormInputX;
        zInput = player.playerInput.NormInputZ;
        jumpInput = player.playerInput.JumpInput;
        runInput = player.playerInput.RunInput;
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }
}

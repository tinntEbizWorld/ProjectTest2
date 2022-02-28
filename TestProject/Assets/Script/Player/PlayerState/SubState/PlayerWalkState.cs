using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerGroundedState
{
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("walking");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.core.movement.PlayerMoveAndRotation(xInput,zInput,playerData.movementVelocity);
        
        if (!isExitingState)
        {
            if (xInput == 0 && zInput == 0) 
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else
            if (runInput)
            {
                stateMachine.ChangeState(player.RunState);
            }
            //else if (yInput == -1)
            //{
            //    stateMachine.ChangeState(player.CrouchMoveState);
            //}
        }

    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}

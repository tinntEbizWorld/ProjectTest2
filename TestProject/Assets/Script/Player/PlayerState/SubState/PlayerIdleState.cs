using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        player.core.movement.setVelocity(0);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (xInput != 0 || zInput != 0)
        {
            stateMachine.ChangeState(player.WalkState);
        }else
        if (runInput)
        {
            stateMachine.ChangeState(player.RunState);
        }
        //if (!isExitingState)
        //{
        //    if (xInput != 0 || yInput !=0)
        //    {
        //        stateMachine.ChangeState(player.WalkState);
        //    }
        //    //else if (yInput == -1)
        //    //{
        //    //    stateMachine.ChangeState(player.CrouchIdleState);
        //    //}
        //}
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}

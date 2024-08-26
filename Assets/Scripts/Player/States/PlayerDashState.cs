using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string animBoolName) : base(_player, _stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.skill.clone.CreateClone(player.transform);

        stateTimer = player.dashDuration;

        rb.gravityScale = 0;
    }

    public override void Exit()
    {
        base.Exit();

        player.SetVelocity(0, rb.velocity.y);

        rb.gravityScale = gravityValue;
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        if(player.IsWallDetected() && !player.IsGroundDetected())
            stateMachine.ChangeState(player.wallSlide);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.idleState);
    }
}

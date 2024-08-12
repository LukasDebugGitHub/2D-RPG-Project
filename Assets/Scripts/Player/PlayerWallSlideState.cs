using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string animBoolName) : base(_player, _stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // doing wall jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJump);
            return;
        }
        
        // player goes of the wall
        if(xInput != 0 && xInput != player.facingDir)
            stateMachine.ChangeState(player.idleState);

        // over the negative y input, move faster down
        if (yInput < 0)
            rb.velocity = new Vector2(rb.velocity.x, -player.wallSlideDownSpeed);
        else
            rb.velocity = new Vector2(rb.velocity.x, -player.wallSlideSpeed);

        // goes to idle, when the player hits the ground
        if (player.IsGroundDetected() || !player.IsWallDetected())
            stateMachine.ChangeState(player.idleState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float attackDir;

    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string animBoolName) : base(_player, _stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        xInput = 0; // bug fix on attack direction

        if (comboCounter > 2 || Time.time >= lastTimeAttacked + player.comboWindow)
            comboCounter = 0;
        
        player.anim.SetInteger("ComboCounter", comboCounter);

        attackDir = player.facingDir;

        if (xInput != 0)
            attackDir = xInput;


        player.SetVelocity(player.attackMovement[comboCounter].x * attackDir, player.attackMovement[comboCounter].y);

        stateTimer = player.attackMoveValue;
    }

    public override void Exit()
    {
        base.Exit();

        comboCounter++;
        lastTimeAttacked = Time.time;

        player.StartCoroutine("BusyFor", player.attackTimeAfterBusy);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            player.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(player.idleState);
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemyBase;
    protected EnemyStateMachine stateMachine;

    private string animBoolName;

    protected bool triggerCalled;
    protected float stateTimer;

    protected Rigidbody2D rb;

    public EnemyState (Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        enemyBase.anim.SetBool(animBoolName, true);
        
        rb = enemyBase.rb;

        triggerCalled = false;
    }

    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);

    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}

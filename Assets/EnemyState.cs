using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;

    private string animBoolName;

    protected bool triggerCalled;
    protected float stateTimer;

    public EnemyState (Enemy _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }

    public virtual void Enter()
    {
        enemy.anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);

    }
}

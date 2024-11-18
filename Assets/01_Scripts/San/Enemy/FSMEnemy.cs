using System;
using UnityEngine;

public abstract class FSMEnemy : CommonEnemy
{
    [SerializeField] protected float _sightRange = 10f, _wallCheckRange = 1f;
    [SerializeField] protected EntityStatesSO _fsmSO;

    protected StateMachine _stateMachine;

    public EntityState CurrentState => _stateMachine.currentState;

    protected override void AfterInit()
    {
        base.AfterInit();
        _stateMachine = new StateMachine(_fsmSO, this);

        GetCompo<EntityAnimator>(true).OnAnimationEnd += HandleAnimationEnd;
    }

    private void HandleAnimationEnd()
    {
        CurrentState.AnimationEndTrigger();
    }

    protected virtual void OnDestroy()
    {
        GetCompo<EntityAnimator>(true).OnAnimationEnd -= HandleAnimationEnd;
    }

    protected virtual void Start()
    {
        _stateMachine.Initialize("Idle");
    }

    protected virtual void Update()
    {
        _stateMachine.UpdateStateMachine();
    }

    public void ChangeState(string stateName)
    {
        _stateMachine.ChangeState(stateName);
    }

    public EntityState GetState(StateSO state)
        => _stateMachine.GetState(state.stateName);
    

    public RaycastHit2D CheckPlayerInRange()
    {
        return Physics2D.Raycast(transform.position, transform.right, _sightRange, _whatIsPlayer);
    }

    public RaycastHit2D CheckObstacleInFront()
    {
        return Physics2D.Raycast(transform.position, transform.right, _wallCheckRange, _whatIsObstacle);
    }

    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * _sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * _wallCheckRange);
    }

}

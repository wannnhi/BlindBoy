using System;
using System.Collections.Generic;
using UnityEngine;

public class Agent : Entity
{
    [Header("FSM")]
    [SerializeField] private EntityStatesSO _playerFSM;


    public EntityState CurrentState => _stateMachine.currentState;

    public Transform target;
    public Transform atkTarget;
    public float jumpPower = 12f;
    public int jumpCount = 2;
    public float dashSpeed = 25f;
    public float dashDuration = 0.2f;

    private int _currentJumpCount = 0;
    private EntityMover _mover;
    private AttackCompo _atkCompo; // 1

    private StateMachine _stateMachine;


    protected override void AfterInit()
    {
        base.AfterInit();

        _mover = GetCompo<EntityMover>();
        _atkCompo = GetCompo<AttackCompo>(); //2

        _stateMachine = new StateMachine(_playerFSM, this);

        GetCompo<EntityAnimator>().OnAnimationEnd += HandleAnimationEnd;
    }

    public void HandleDash()
    {
        if(_atkCompo.AttemptSkill())
        {
            ChangeState("Dash");
        }
    }

    private void HandleAnimationEnd()
    {
        CurrentState.AnimationEndTrigger();
    }

    public void HandleAttack()
    {
        if (_atkCompo.AttemptAttack())
            ChangeState("Attack");
    }

    public float CheckEnemyDistance()
    {
        // 모든 충돌체 가져오기
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, status.checkRadius, status.whatIsTarget);

        if (cols.Length > 0)
        {
            Collider2D closestTarget = null;
            float closestDistance = float.MaxValue;

            foreach (var col in cols)
            {
                Vector2 direction = col.transform.position - transform.position;
                float distance = direction.magnitude;
                float angle = Vector2.Angle(direction.normalized, transform.right);

                if (angle <= status.checkAngle * 0.5f)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, direction.normalized, distance, status.whatIsObstacle);

                    if (hit.collider == null && col.TryGetComponent(out Agent enemy))
                    {
                        if (distance < closestDistance)
                        {
                            closestTarget = col;
                            closestDistance = distance;
                        }
                    }
                }
            }

            if (closestTarget != null)
            {
                atkTarget = closestTarget.transform;
                return closestDistance;
            }
        }

        return -1f;
    }

    private void OnDestroy()
    {
        GetCompo<EntityAnimator>().OnAnimationEnd -= HandleAnimationEnd;
    }

    private void Start()
    {
        _stateMachine.Initialize("Idle");
    }

    public EntityState GetState(StateSO state) 
        => _stateMachine.GetState(state.stateName);

    public void ChangeState(string newState) 
        => _stateMachine.ChangeState(newState);
    
    private void HandleGroundStateChange(bool isGrounded)
    {
        if (isGrounded)
            _currentJumpCount = jumpCount;
    }

    private void Update()
    {
        _stateMachine.currentState.Update();
    }
}
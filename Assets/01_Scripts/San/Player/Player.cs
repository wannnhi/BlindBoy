using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("FSM")]
    [SerializeField] private EntityStatesSO _playerFSM;

    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    public EntityState CurrentState => _stateMachine.currentState;

    public AnimParamSO hitGroundParam;
    public float jumpPower = 12f;
    public int jumpCount = 2;
    public float dashSpeed = 25f;
    public float dashDuration = 0.2f;

    private int _currentJumpCount = 0;
    private EntityMover _mover;
    private PlayerAttackCompo _atkCompo; // 1

    private StateMachine _stateMachine;

    protected override void AfterInit()
    {
        base.AfterInit();

        _mover = GetCompo<EntityMover>();
        _atkCompo = GetCompo<PlayerAttackCompo>(); //2

        _stateMachine = new StateMachine(_playerFSM, this);

        _mover.OnGroundStateChange += HandleGroundStateChange;
        PlayerInput.JumpEvent += HandleJumpEvent;
        PlayerInput.AttackEvent += HandleAttackEvent;
        PlayerInput.DashEvent += HandleDashEvent;

        GetCompo<EntityAnimator>().OnAnimationEnd += HandleAnimationEnd;
    }

    private void HandleDashEvent()
    {
        if(_atkCompo.AttemptDash())
        {
            ChangeState("Dash");
        }
    }

    private void HandleAnimationEnd()
    {
        CurrentState.AnimationEndTrigger();
    }

    private void HandleAttackEvent()
    {
        if (_atkCompo.AttemptAttack())
            ChangeState("Attack");
    }

    private void HandleJumpEvent()
    {
        if(_mover.IsGrounded || _currentJumpCount > 0)
        {
            string nextName = _currentJumpCount == jumpCount ? "Jump" : "DoubleJump";
            _currentJumpCount--;

            ChangeState(nextName);
        }
    }

    private void OnDestroy()
    {
        _mover.OnGroundStateChange -= HandleGroundStateChange;
        PlayerInput.JumpEvent -= HandleJumpEvent;
        PlayerInput.AttackEvent -= HandleAttackEvent;
        PlayerInput.DashEvent -= HandleDashEvent;
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


// 파생 클래스가 기본 클래스를 대체할 수 있어야 한다. 
// 부모가 있던 곳에 자식을 넣으면 잘 굴러가야해
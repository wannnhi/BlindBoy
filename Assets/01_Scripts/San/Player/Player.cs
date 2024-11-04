using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("FSM")]
    [SerializeField] private EntityStatesSO _playerFSM;

    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    public EntityState CurrentState => _stateMachine.currentState;

    private int _currentJumpCount = 0;
    private EntityMover _mover;
    private PlayerAttackCompo _atkCompo;

    private StateMachine _stateMachine;

    protected override void AfterInit()
    {
        base.AfterInit();

        _mover = GetCompo<EntityMover>();
        _atkCompo = GetCompo<PlayerAttackCompo>();

        _stateMachine = new StateMachine(_playerFSM, this);

        PlayerInput.OnRMouseEvent += HandleAttackEvent;

        GetCompo<EntityAnimator>().OnAnimationEnd += HandleAnimationEnd;
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


    private void OnDestroy()
    {
        PlayerInput.OnRMouseEvent -= HandleAttackEvent;
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
    

    private void Update()
    {
        _stateMachine.currentState.Update();
    }
}

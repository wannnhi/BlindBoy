using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("FSM")]
    public StateSO idleState;
    public StateSO moveState;
    [SerializeField] private List<StateSO> _stateList;

    [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

    private EntityMover _mover;
    private StateMachine _stateMachine;
    private Dictionary<StateSO, EntityState> _stateDictionary;

    protected override void Awake()
    {
        base.Awake();
        _mover = GetCompo<EntityMover>();

        _stateMachine = new StateMachine();
        _stateDictionary = new Dictionary<StateSO, EntityState>();

        foreach (StateSO state in _stateList)
        {
            try
            {
                Type type = Type.GetType(state.className);
                var playerState = Activator.CreateInstance(type, this, state.stateAnim) as EntityState;
                _stateDictionary.Add(state, playerState);
            }
            catch (Exception ex)
            {
                Debug.LogError($"<color=red>{state.className}</color> loading error, Message : {ex.Message}");
            }
        }
    }

    private void Start()
    {
        _stateMachine.Initialize(GetState(idleState));
    }

    public EntityState GetState(StateSO state) => _stateDictionary.GetValueOrDefault(state);

    public void ChangeState(StateSO newState)
    {
        _stateMachine.ChangeState(GetState(newState));
    }

    private void Update()
    {
        _stateMachine.currentState.Update();
    }
}

using System;
using UnityEngine;

public abstract class AttackCompo : MonoBehaviour, IEntityComponent
{
    protected EntityAnimator _animator;

    [SerializeField] private StateSO _atkState;
    [SerializeField] private StateSO _skillState;
    [SerializeField] private DamageCaster _damageCaster;


    protected Agent _agent;
    protected float _lastAtkTime;
    protected float _lastDashTime;


    public void Initialize(Entity entity)
    {
        _agent = entity as Agent;
        _damageCaster.InitCaster(entity);
    }

    public bool AttemptSkill()
    {
        if (_agent.CurrentState == _agent.GetState(_skillState)) return false;
        if (_lastDashTime + _agent.status.skilCoolDown > Time.time) return false;

        _lastDashTime = Time.time;
        return true;
    }

    public bool AttemptAttack()
    {
        if (_agent.CurrentState == _agent.GetState(_atkState)) return false;
        if (_lastAtkTime + _agent.status.atkDelay > Time.time) return false;

        _lastAtkTime = Time.time;
        AttackEnter();
        return true;
    }

    protected abstract void AttackEnter();
    private void CastAttack()
    {
        _damageCaster.CastDamage();
    }
}

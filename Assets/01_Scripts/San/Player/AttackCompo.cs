using System;
using UnityEngine;

public abstract class AttackCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private StateSO _atkState;
    [SerializeField] private StateSO _skillState;
    [SerializeField] private DamageCaster _damageCaster;
    
    private Agent _agent;
    private float _lastAtkTime;
    private float _lastDashTime;


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

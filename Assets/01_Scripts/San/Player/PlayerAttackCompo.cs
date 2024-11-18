using System;
using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private float _atkCooldown;
    [SerializeField] private StateSO _atkState;
    [SerializeField] private float _dashCooltime;
    [SerializeField] private StateSO _dashState;
    [SerializeField] private AnimParamSO _atkTriggerParam;
    [SerializeField] private DamageCaster _damageCaster;
    
    private Player _player;
    private float _lastAtkTime;
    private float _lastDashTime;

    private Animator _animator;

    public void Initialize(Entity entity)
    {
        _player = entity as Player;
        _animator = GetComponent<Animator>();
        _damageCaster.InitCaster(entity);
    }

    public bool AttemptDash()
    {
        if (_player.CurrentState == _player.GetState(_dashState)) return false;
        if (_lastDashTime + _dashCooltime > Time.time) return false;

        _lastDashTime = Time.time;
        return true;
    }

    public bool AttemptAttack()
    {
        if (_player.CurrentState == _player.GetState(_atkState)) return false;
        if (_lastAtkTime + _atkCooldown > Time.time) return false;

        _lastAtkTime = Time.time;
        Attack();
        return true;
    }

    private void Attack()
    {
        _animator.SetTrigger(_atkTriggerParam.hashValue);
    }

    private void CastAttack()
    {
        _damageCaster.CastDamage();
    }
}

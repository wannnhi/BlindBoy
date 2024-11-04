using System;
using UnityEngine;

public class PlayerAttackCompo : MonoBehaviour, IEntityComponent
{
    [SerializeField] private float _atkCooldown;
    [SerializeField] private StateSO _atkState;

    private Player _player;
    private float _lastAtkTime;

    public void Initialize(Entity entity)
    {
        _player = entity as Player;
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
        Debug.Log("Attack");
    }
}

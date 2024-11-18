using System;
using UnityEngine;

public abstract class PlayerAirState : EntityState
{
    protected Player _player;
    protected EntityMover _mover;

    protected PlayerAirState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
        _mover = _player.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.SpeedMultiplier = 0.6f;
    }

    public override void Update()
    {
        base.Update();
        Vector2 moveDir = _player.target.position - _player.transform.position;
        float xMove = moveDir.x;

        if (Mathf.Abs(xMove) > 0)
            _mover.SetXMovement(xMove);

    }

    public override void Exit()
    {
        _mover.SpeedMultiplier = 1f;
        base.Exit();
    }
}

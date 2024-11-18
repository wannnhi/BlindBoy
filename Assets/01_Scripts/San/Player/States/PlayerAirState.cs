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
        _mover.SpeedMultiplier = 0.7f;
        _player.PlayerInput.LandingEvent += HandleLandingEvent;
    }

    private void HandleLandingEvent()
    {
        _mover.AddForceToEntity(new Vector2(0, -30f));
        _player.ChangeState("Landing");
    }

    public override void Update()
    {
        base.Update();
        float xInput = _player.PlayerInput.InputDirection.x;
        if (Mathf.Abs(xInput) > 0)
            _mover.SetXMovement(xInput);

    }

    public override void Exit()
    {
        _player.PlayerInput.LandingEvent -= HandleLandingEvent;
        _mover.SpeedMultiplier = 1f;
        base.Exit();
    }
}

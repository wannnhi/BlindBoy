using UnityEngine;

public class PlayerLandingState : EntityState
{
    private const float LANDING_DELAY_TIME = 0.3f;
    private Player _player;
    private EntityMover _mover;

    private bool _isHitGround;
    private float _landingStartTime;

    public PlayerLandingState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
        _mover = _player.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.CanManualMove = false;
        _isHitGround = false;
    }

    public override void Update()
    {
        base.Update();

        if(_isHitGround == false && _mover.IsGrounded)
        {
            _isHitGround = true;
            _landingStartTime = Time.time;
            _renderer.SetParam(_player.hitGroundParam);
        }

        if(_isHitGround && _landingStartTime + LANDING_DELAY_TIME < Time.time)
        {
            _player.ChangeState("Idle");
        }
    }

    public override void Exit()
    {
        _mover.CanManualMove = true;
        base.Exit();
    }
}

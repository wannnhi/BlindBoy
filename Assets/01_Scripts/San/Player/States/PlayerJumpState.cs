using UnityEngine;

public class PlayerJumpState : AgentAirState
{
    public PlayerJumpState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _mover.StopImmediately(true);
        _mover.AddForceToEntity(new Vector2(0, _player.jumpPower));
    }

    public override void Update()
    {
        base.Update();
        if(_mover.Velocity.y < 0)
        {
            _player.ChangeState("Fall");
        }
    }
}


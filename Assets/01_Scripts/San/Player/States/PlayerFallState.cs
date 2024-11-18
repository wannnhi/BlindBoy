using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    
    public PlayerFallState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
    }

    public override void Update()
    {
        base.Update();
        if(_mover.IsGrounded)
        {
            _player.ChangeState("Idle");
        }
    }
}

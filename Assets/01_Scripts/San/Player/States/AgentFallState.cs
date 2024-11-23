using UnityEngine;

public class AgentFallState : AgentAirState
{

    public AgentFallState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
    }

    public override void Update()
    {
        base.Update();
        if (_mover.IsGrounded)
        {
            _player.ChangeState("Idle");
        }
    }
}

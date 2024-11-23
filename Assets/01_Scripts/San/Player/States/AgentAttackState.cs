using UnityEngine;

public class AgentAttackState : EntityState
{
    private Agent _agent;
    private EntityMover _mover;

    public AgentAttackState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _agent = entity as Agent;
        _mover = _agent.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.StopImmediately(false);
        _mover.CanManualMove = false;
        _mover.AddForceToEntity(new Vector2(_renderer.FacingDirection * 1f, 0));
    }

    public override void Exit()
    {
        _mover.CanManualMove = true;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(_isTriggerCall)
        {
            _agent.ChangeState("Idle");
        }
    }

    private void FacingToEnemy()
    {
        
    }

}

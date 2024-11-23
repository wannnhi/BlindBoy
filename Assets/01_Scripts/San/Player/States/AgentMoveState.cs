using UnityEditor.VersionControl;
using UnityEngine;

public class AgentMoveState : EntityState
{
    private Agent _agent;
    private EntityMover _mover;
    

    public AgentMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _agent = entity as Agent;
        _mover = _agent.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        Vector2 moveDir = _agent.target.position - _agent.transform.position;
        float xMove = moveDir.x;

        _mover.SetXMovement(xMove);

    }

    public override void Update()
    {
        base.Update();
        if(_agent.status.checkRadius <= _agent.CheckEnemyDistance())
        {
            _agent.ChangeState("Attack");
        }
        if (Mathf.Approximately(Mathf.Abs(_mover.Velocity.x), 0))
            _agent.ChangeState("Idle");
    }

    
}

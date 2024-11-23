using UnityEngine;

public class AgentIdleState : EntityState
{
    private Agent _agent;
    private EntityMover _mover;

    public AgentIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _agent = entity as Agent;
        _mover = entity.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.StopImmediately(false);
    }

    public override void Update()
    {
        base.Update();
        _agent.target = GameObject.FindGameObjectWithTag("EnemyBuilding").transform;
        if (_agent.status.checkRadius <= _agent.CheckEnemyDistance())
        {
            _agent.ChangeState("Attack");
        }
        if (_agent.target != null)
            _agent.ChangeState("Move");
    }
}

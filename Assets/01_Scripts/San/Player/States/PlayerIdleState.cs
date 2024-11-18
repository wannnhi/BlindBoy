using UnityEngine;

public class PlayerIdleState : EntityState
{
    private Player _player;
    private EntityMover _mover;

    public PlayerIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
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
        _player.target = GameObject.FindGameObjectWithTag("EnemyBuilding").transform;
        if (_player.status.checkRadius <= _player.CheckEnemyDistance())
        {
            _player.ChangeState("Attack");
        }
        if (_player.target != null)
            _player.ChangeState("Move");
    }
}

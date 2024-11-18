using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerMoveState : EntityState
{
    private Player _player;
    private EntityMover _mover;
    

    public PlayerMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
        _mover = _player.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        Vector2 moveDir = _player.target.position - _player.transform.position;
        float xMove = moveDir.x;

        _mover.SetXMovement(xMove);

    }

    public override void Update()
    {
        base.Update();
        if(_player.status.checkRadius <= _player.CheckEnemyDistance())
        {
            _player.ChangeState("Attack");
        }
        if (Mathf.Approximately(Mathf.Abs(_mover.Velocity.x), 0))
            _player.ChangeState("Idle");
    }

    
}

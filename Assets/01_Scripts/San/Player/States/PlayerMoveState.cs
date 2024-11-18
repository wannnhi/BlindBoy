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

    public override void Update()
    {
        base.Update();
        float xMove = _player.PlayerInput.InputDirection.x;

        _mover.SetXMovement(xMove);

        if (Mathf.Approximately(xMove, 0))
            _player.ChangeState("Idle");
    }
}

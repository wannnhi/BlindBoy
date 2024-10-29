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

        Vector2 moveInput = _player.PlayerInput.InputDirection;

        _mover.SetMovement(moveInput);

        if (Mathf.Approximately(moveInput.magnitude, 0))
        {
            _player.ChangeState(_player.idleState);
        }
    }
}

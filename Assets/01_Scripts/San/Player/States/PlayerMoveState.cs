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

        Vector2 moveDirection = _player.PlayerInput.InputDirection;

        _mover.SetMovementInput(moveDirection);

        if (moveDirection != Vector2.zero)
        {
            _player.AnimCompo.SetFloat("LastMoveX", moveDirection.x);
            _player.AnimCompo.SetFloat("LastMoveY", moveDirection.y);
        }
        if (moveDirection == Vector2.zero)
            _player.ChangeState("Idle");
    }
}

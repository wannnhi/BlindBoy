using UnityEngine;

public class PlayerTopDownMoveState : EntityState
{
    private TopDownPlayer _player;
    private EntityTopDownMover _mover;

    public PlayerTopDownMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as TopDownPlayer;
        _mover = _player.GetCompo<EntityTopDownMover>();
    }

    public override void Update()
    {
        base.Update();

        Vector2 moveDirection = _player.PlayerInput.InputDirection;

        _mover.SetMovementInput(moveDirection);

        
        if (moveDirection == Vector2.zero)
            _player.ChangeState("Idle");
    }
}

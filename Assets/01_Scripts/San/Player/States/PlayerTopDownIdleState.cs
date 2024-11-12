using UnityEngine;

public class PlayerTopDownIdleState : EntityState
{
    private TopDownPlayer _player;
    private EntityTopDownMover _mover;

    public PlayerTopDownIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as TopDownPlayer;
        _mover = entity.GetCompo<EntityTopDownMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.StopImmediately();
    }

    public override void Update()
    {
        base.Update();
        float xMove = _player.PlayerInput.InputDirection.x;
        float yMove = _player.PlayerInput.InputDirection.y;
        if (Mathf.Abs(xMove) > 0 || Mathf.Abs(yMove) > 0)
            _player.ChangeState("Move");
    }
}

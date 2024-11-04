using UnityEngine;

public class PlayerAttackState : EntityState
{
    private Player _player;
    private EntityMover _mover;

    public PlayerAttackState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as Player;
        _mover = _player.GetCompo<EntityMover>();
    }

    public override void Enter()
    {
        base.Enter();
        _mover.StopImmediately();
    }

    public override void Update()
    {
        base.Update();
        if(_isTriggerCall)
        {
            _player.ChangeState("Idle");
        }
    }
}

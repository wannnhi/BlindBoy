using UnityEngine;

public class PlayerAttackState : EntityState
{
    private TopDownPlayer _player;
    private EntityTopDownMover _mover;

    public PlayerAttackState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
    {
        _player = entity as TopDownPlayer;
        _mover = _player.GetCompo<EntityTopDownMover>();
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

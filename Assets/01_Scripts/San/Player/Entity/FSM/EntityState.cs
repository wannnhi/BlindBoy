using UnityEngine;

public class EntityState
{
    protected EntityRenderer _renderer;
    private Entity _entity;
    private AnimParamSO _animParam;
    private bool _isTriggerCall;

    public EntityState(Entity entity, AnimParamSO animParam)
    {
        _entity = entity;
        _animParam = animParam;
        _renderer = _entity.GetComponent<EntityRenderer>();
    }

    public virtual void Enter()
    {
        _renderer.SetParam(_animParam, true);
        _isTriggerCall = false;
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        _renderer.SetParam(_animParam, false);
    }
}

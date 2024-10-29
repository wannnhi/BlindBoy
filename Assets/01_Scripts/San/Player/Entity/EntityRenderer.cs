using System;
using UnityEngine;

public class EntityRenderer : MonoBehaviour, IEntityComponent
{
    public float FacingDirection { get; private set; } = 1; //오른쪽이 1, 왼쪽이 -1
    private Entity _entity;
    private Animator _animator;



    public void Initialize(Entity entity)
    {
        _entity = entity;
        _animator = GetComponent<Animator>();
    }


    public void SetParam(AnimParamSO param, bool value)
        => _animator.SetBool(param.hashValue, value);
    public void SetParam(AnimParamSO param, float value)
        => _animator.SetFloat(param.hashValue, value);
    public void SetParam(AnimParamSO param, int value)
        => _animator.SetInteger(param.hashValue, value);
    public void SetParam(AnimParamSO param)
        => _animator.SetTrigger(param.hashValue);


    #region Flip Controller
    public void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0, 180f, 0);
    }

    public void FlipController(float xMove)
    {
        if (Mathf.Abs(FacingDirection + xMove) < 0.5f)
            Flip();
    }

    #endregion
}

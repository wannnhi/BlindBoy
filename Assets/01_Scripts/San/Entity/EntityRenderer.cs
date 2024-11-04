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
        float xScale = _entity.transform.localScale.x;
        _entity.transform.localScale = new Vector3(xScale * -1, _entity.transform.localScale.y, _entity.transform.localScale.z);
    }

    public void FlipController(float xMove)
    {
        if (Mathf.Abs(xMove) > 0.01f)
        {
            if ((xMove > 0 && FacingDirection < 0) || (xMove < 0 && FacingDirection > 0))
            {
                Flip();
            }
        }
    }




    #endregion
}

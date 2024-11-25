using UnityEngine;

public class ArcableAttackCompo : AttackCompo
{
    [SerializeField] private AnimParamSO _atkTriggerParam;

    

    protected override void AttackEnter()
    {
        _animator.animCompo.SetTrigger(_atkTriggerParam.hashValue);
    }
}

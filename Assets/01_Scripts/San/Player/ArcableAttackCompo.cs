using UnityEngine;

public class ArcableAttackCompo : AttackCompo
{
    [SerializeField] private AnimParamSO _atkTriggerParam;

    private Animator _animCompo;


    private void Awake()
    {
        _animCompo = GetComponent<Animator>();
    }

    protected override void AttackEnter()
    {
        _animCompo.SetTrigger(_atkTriggerParam.hashValue);
    }
}

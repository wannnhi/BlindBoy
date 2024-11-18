using System;
using UnityEngine;

public class OverlapDamageCaster : DamageCaster
{
    [SerializeField] private Vector2 _castSize;
    private Collider2D[] _colliders;
    public override void InitCaster(Entity owner)
    {
        base.InitCaster(owner);
        _colliders = new Collider2D[_maxAvailableCount];
    }

    public override void CastDamage()
    {
        Vector2 start = (Vector2)transform.position - _castSize * 0.5f;
        Vector2 end = start + _castSize;

        int cnt = Physics2D.OverlapArea(start, end, _contactFilter, _colliders);

        Vector2 atkDirection = _owner.transform.right;
        Vector2 knockbackForce = _knockbackForce;
        knockbackForce.x *= atkDirection.x;

        for (int i = 0; i < cnt; i++)
        {
            if (_colliders[i].TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_damage,atkDirection, knockbackForce,_owner);
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, _castSize);
    }
#endif
}
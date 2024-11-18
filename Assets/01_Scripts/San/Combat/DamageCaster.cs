using UnityEngine;

public abstract class DamageCaster : MonoBehaviour
{
    [SerializeField] protected ContactFilter2D _contactFilter;
    [SerializeField] protected int _maxAvailableCount = 4;
    [SerializeField] protected float _damage;
    [SerializeField] protected Vector2 _knockbackForce;

    protected Entity _owner;

    public virtual void InitCaster(Entity owner)
    {
        _owner = owner;
    }

    public abstract void CastDamage();
}

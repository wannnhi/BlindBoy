using System;
using System.Collections;
using UnityEngine;

public class EntityHealth : MonoBehaviour, IEntityComponent, IDamageable
{
    [SerializeField] private float _maxHealth = 50f;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _knockbackTime = 0.5f;
    private Entity _entity;
    private EntityMover _mover;

    public event Action<Entity> OnHitEvent;
    public event Action OnDeathEvent;


    public void Initialize(Entity entity)
    {
        _entity = entity;
        _mover = entity.GetCompo<EntityMover>();
        _currentHealth = _maxHealth;
    }
    public void ApplyDamage(float damage, Vector2 direction, Vector2 knockback, Entity dealer)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, _maxHealth);
        StartCoroutine(ApplyKnockback(knockback));
        OnHitEvent?.Invoke(dealer);

        if(_currentHealth <= 0)
        {
            OnDeathEvent?.Invoke();
            Debug.Log("?");
        }
    }

    private IEnumerator ApplyKnockback(Vector2 knockback)
    {
        _mover.CanManualMove = false;
        _mover.StopImmediately(true);
        _mover.AddForceToEntity(knockback);
        yield return new WaitForSeconds(_knockbackTime);
        _mover.CanManualMove = true;
    }
}

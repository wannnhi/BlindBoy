using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EntityHealth : MonoBehaviour, IEntityComponent
{
    public float maxHealth = 100;

    public float CurrentHealth;
    Entity _onwer;
    EntityTopDownMover _mover;

    public bool IsHittable { get; set; } = true;


    public UnityEvent OnGetHit;
    public UnityEvent<int> OnGetDamageEvent;
    public UnityEvent OnDeadEvent;
    //public Pooling pool;

    public void Initialize(Entity agent)
    {
        _onwer = agent;
        _mover = _onwer.GetCompo<EntityTopDownMover>();
        ResetHealth();
    }
    public void ResetHealth()
    {
        StartCoroutine(ResetHealthCoroutine());
    }

    private IEnumerator ResetHealthCoroutine()
    {
        while (CurrentHealth <= 0)
        {
            CurrentHealth = maxHealth;
            yield return null;
        }
    }

    public void AddCurrentHP(int addHealth)
    {
        if (addHealth + CurrentHealth > maxHealth)
        {
            CurrentHealth = maxHealth;
        }
        else
        {
            CurrentHealth += addHealth;
        }
    }

    public float GetCurrentHP()
    {
        return CurrentHealth;
    }


    public void TakeDamage(float amount, Vector2 dir, float knockbackPower)
    {
        if (IsHittable)
        {
            CurrentHealth -= amount;
            OnGetHit?.Invoke();
            //if (knockbackPower > 0)
            //    _mover.GetKnockback(dir, knockbackPower);
            OnGetDamageEvent?.Invoke((int)amount);
            
            
            if (CurrentHealth <= 0)
            {
                OnDeadEvent?.Invoke();
                //ResetHealth();
            }

        }
    }
}

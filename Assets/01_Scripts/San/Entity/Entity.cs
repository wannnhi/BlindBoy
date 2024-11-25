using Redcode.Pools;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour, IPoolObject
{
    public bool IsDead { get; set; }
    protected Dictionary<Type, IEntityComponent> _components;

    public EnityStatus status;

    protected virtual void Awake()
    {
        
    }

    private void InitComponents()
    {
        _components.Values.ToList().ForEach(component => component.Initialize(this));
    }

    protected virtual void AfterInit()
    {
        _components.Values.ToList().ForEach(component => {
            if(component is IAfterInitable afterInitable)
            {
                afterInitable.AfterInit();
            }
        });
    }

    public T GetCompo<T>(bool isDerived = false) where T : IEntityComponent
    {
        if(_components.TryGetValue(typeof(T), out IEntityComponent component))
        {
            return (T)component;
        }

        if(isDerived == true)
        {
            Type findType = _components.Keys.FirstOrDefault(t => t.IsSubclassOf(typeof(T)));
            if (findType != null)
                return (T)_components[findType];
        }

        return default;
    }

    public void OnCreatedInPool()
    {
        _components = new Dictionary<Type, IEntityComponent>();
        GetComponentsInChildren<IEntityComponent>(true).ToList()
            .ForEach(component => _components.Add(component.GetType(), component));

        InitComponents();
        AfterInit();
    }

    public void OnGettingFromPool()
    {
        _components = new Dictionary<Type, IEntityComponent>();
        GetComponentsInChildren<IEntityComponent>(true).ToList()
            .ForEach(component => _components.Add(component.GetType(), component));

        InitComponents();
        AfterInit();
    }
}

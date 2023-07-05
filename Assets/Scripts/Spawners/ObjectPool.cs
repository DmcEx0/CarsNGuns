using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private List<T> _pool;
    private Transform _container;
    private T _prefab;

    public ObjectPool(T prefab, int count)
    {
        _prefab = prefab;

        CreatePool(count);
    }

    public T GetElement()
    {
        if (HasFreeElement(out var element))
            return element;
        else
            return CreateObject(_container, true);


        throw new Exception($"There is no free element in pool of type {typeof(T)}");
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();
        GameObject poolContainer = new GameObject(_prefab.ToString());
        _container = poolContainer.transform;

        for (int i = 0; i < count; i++)
        {
            CreateObject(_container);
        }
    }

    private T CreateObject(Transform poolContainer, bool isActiveByDefault = false)
    {
        var createdObject = GameObject.Instantiate(_prefab, poolContainer.transform);
        createdObject.gameObject.SetActive(isActiveByDefault);

        _pool.Add(createdObject);

        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var elementInPool in _pool)
        {
            if (elementInPool.gameObject.activeInHierarchy == false)
            {
                element = elementInPool;
                elementInPool.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }
}
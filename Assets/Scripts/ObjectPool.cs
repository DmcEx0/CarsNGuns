using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    protected T _prefab;
    private List<T> _prefabs;
    private Transform _container;
    private List<T> _pool;

    private bool _isAutoExpand;

    public ObjectPool(T prefab, int count, Transform container, bool isAutoExpand)
    {
        _prefab = prefab;
        _container = container;
        _isAutoExpand = isAutoExpand;

        CreatePool(count);
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
            return element;

        if (_isAutoExpand && _prefabs == null)
            return CreateObject(true);

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
            CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = GameObject.Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(isActiveByDefault);

        _pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var mono in _pool)
        {
            if (mono.gameObject.activeInHierarchy == false)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }
}

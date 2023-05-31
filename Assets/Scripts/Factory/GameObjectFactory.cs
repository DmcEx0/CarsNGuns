using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    private List<Queue<T>> _poolList = new List<Queue<T>>();
    private Queue<T> _pool;

    private T _elemet;

    protected abstract T GetTemplate(T element);
    protected abstract void Spawn(Transform spawnPoint);

    public T GetElement()
    {
        if (_poolList.Count > 0)
        {
            if (HasFreeElement(out var element))
                return element;
        }
        else
        {
            var element = Instantiate(GetTemplate(_elemet));
            return element;
        }

        throw new System.Exception($"There is no free elements in pool of type {typeof(T)}");
    }

    protected void CreatePool(T element, int numberOfObjects, string transformParentName)
    {
        _pool = new Queue<T>();

        GameObject container = new GameObject(transformParentName);
        container.transform.SetParent(transform);


        for (int i = 0; i < numberOfObjects; i++)
            CreateObject(GetTemplate(element), container.transform);

        _poolList.Add(_pool);
    }

    private T CreateObject(T element, Transform poolContainer)
    {
        var createdObject = GameObject.Instantiate(GetTemplate(element), poolContainer);
        createdObject.gameObject.SetActive(false);

        _pool.Enqueue(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        if (_poolList.Count > 0)
        {
            int indexOfPool = Random.Range(0, _poolList.Count);
            Debug.Log(indexOfPool);

            foreach (var mono in _poolList[indexOfPool])
            {
                if (mono.gameObject.activeInHierarchy == false)
                {
                    element = mono;
                    mono.gameObject.SetActive(true);
                    return true;
                }
            }
        }

        element = null;
        return false;
    }
}

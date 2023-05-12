using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    [SerializeField] private string _containerName;

    [SerializeField] protected int PoolCount = 5;
    [SerializeField] protected bool IsAutoExpand = false;

    protected List<Transform> SpawnPoints;

    protected GameObject Container;

    protected void SetSpawnPoints(Transform spawnPointContainer)
    {
        SpawnPoints = new List<Transform>();
        
        for (int i = 0; i < spawnPointContainer.childCount; i++)
        {
            SpawnPoints.Add(spawnPointContainer.GetChild(i));
        }
    }

    protected virtual void CreatePool()
    {
        GameObject container = new GameObject(_containerName);
        container.transform.SetParent(transform);
        Container = container;
    }

    protected abstract void Spawn();
}

using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawner : Spawner
{
    [SerializeField] private List<EnemyCar> _enemiesCars;

    [SerializeField] private int _minNumberOfEnemyCar = 4;
    [SerializeField] private int _maxNumberOfEnemyCar = 9;

    private TrackSpawner _trackSpawner;
    private List<ObjectPool<EnemyCar>> _pools;

    private int _numberOfEnemiesCars;

    private void OnEnable()
    {
        _trackSpawner.EnemyCarSpawned += SetSpawnPointOnTrack;
    }

    private void OnDisable()
    {
        _trackSpawner.EnemyCarSpawned -= SetSpawnPointOnTrack;
    }

    private void Awake()
    {
        _trackSpawner = GetComponent<TrackSpawner>();
    }

    private void Start()
    {
        _pools = new List<ObjectPool<EnemyCar>>();
        CreatePool();
    }

    protected override void Spawn()
    {
        _numberOfEnemiesCars = Random.Range(_minNumberOfEnemyCar, _maxNumberOfEnemyCar);

        for (int i = 0; i < _numberOfEnemiesCars; i++)
        {
            int indexOfSpawnPoint = Random.Range(0, SpawnPoints.Count);
            int indexOfPool = Random.Range(0, _pools.Count);

            EnemyCar newEnemyCar = _pools[indexOfPool].GetFreeElement();
            newEnemyCar.transform.rotation = Quaternion.identity;
            newEnemyCar.transform.position = SpawnPoints[indexOfSpawnPoint].transform.position;
            SpawnPoints.RemoveAt(indexOfSpawnPoint);
        }
    }

    protected override void CreatePool()
    {
        base.CreatePool();

        foreach (var enemyCar in _enemiesCars)
        {
            _pools.Add(new ObjectPool<EnemyCar>(enemyCar, PoolCount, Container.transform, IsAutoExpand));
        }
    }

    private void SetSpawnPointOnTrack(Transform spawnPointContaine)
    {
        SetSpawnPoints(spawnPointContaine);
        Spawn();
    }
}
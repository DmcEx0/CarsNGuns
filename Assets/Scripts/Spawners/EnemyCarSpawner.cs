using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCarSpawner : Spawner
{
    [SerializeField] private EnemyCar _enemyCar;

    [SerializeField] private int _minNumberOfEnemyCar = 4;
    [SerializeField] private int _maxNumberOfEnemyCar = 9;

    private TrackSpawner _trackSpawner;
    private ObjectPool<EnemyCar> _pool;

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
        CreatePool();
    }

    protected override void Spawn()
    {
        _numberOfEnemiesCars = Random.Range(_minNumberOfEnemyCar, _maxNumberOfEnemyCar);

        for (int i = 0; i < _numberOfEnemiesCars; i++)
        {
            int indexOfSpawnPoint = Random.Range(0, SpawnPoints.Count);

            EnemyCar enemyCar = _pool.GetFreeElement();
            enemyCar.transform.position = SpawnPoints[indexOfSpawnPoint].transform.position;
            SpawnPoints.RemoveAt(indexOfSpawnPoint);
        }
    }

    protected override void CreatePool()
    {
        base.CreatePool();

        _pool = new ObjectPool<EnemyCar>(_enemyCar, PoolCount, Container.transform, IsAutoExpand);
    }

    private void SetSpawnPointOnTrack(Transform spawnPointContaine)
    {
        SetSpawnPoints(spawnPointContaine);
        Spawn();
    }
}
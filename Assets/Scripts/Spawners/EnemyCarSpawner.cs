using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCarSpawner : Spawner
{
    [SerializeField] private int _numberOfEnemyCarsInPool;
    [SerializeField] private int _numberOfEnemyCarsWithDropInPool;

    [SerializeField] private EnemyCarWithDrop _enemyCarsWithDrop;
    [SerializeField] private List<EnemyCar> _enemiesCars;

    [SerializeField] private int _minNumberOfEnemyCarOnTrack = 4;
    [SerializeField] private int _maxNumberOfEnemyCarOnTrack = 9;

    private ObjectPool<EnemyCarWithDrop> _enemyCarWithDropPool;
    private ObjectPool<EnemyCar> _enemyCarPool;
    private List<ObjectPool<EnemyCar>> _poolList;

    private List<Transform> _spawnPoints;

    private bool _isSpawnedEnemyWithDrop;

    private TrackSpawner _trackSpawner;

    private void OnEnable()
    {
        _trackSpawner.EnemyCarSpawned += Spawn;
        _trackSpawner.EnemyWithDropSpawned += SetFlagForSpawnEnemyWithDrop;
    }

    private void OnDisable()
    {
        _trackSpawner.EnemyCarSpawned -= Spawn;
        _trackSpawner.EnemyWithDropSpawned -= SetFlagForSpawnEnemyWithDrop;
    }

    private void Awake()
    {
        _trackSpawner = GetComponent<TrackSpawner>(); // сильная связь - плохо
    }

    private void Start()
    {
        _poolList = new List<ObjectPool<EnemyCar>>();

        for (int i = 0; i < _enemiesCars.Count; i++)
        {
            _enemyCarPool = new ObjectPool<EnemyCar>(_enemiesCars[i], _numberOfEnemyCarsInPool);
            _poolList.Add(_enemyCarPool);
        }

        _enemyCarWithDropPool = new ObjectPool<EnemyCarWithDrop>(_enemyCarsWithDrop, _numberOfEnemyCarsWithDropInPool);
    }

    protected override void Spawn(Transform spawnPointContainer)
    {
        SetSpawnPoints(spawnPointContainer);

        int numberOfEnemiesCars = Random.Range(_minNumberOfEnemyCarOnTrack, _maxNumberOfEnemyCarOnTrack);

        for (int i = 0; i < numberOfEnemiesCars; i++)
        {
            int indexOfSpawnPoint = Random.Range(0, _spawnPoints.Count);

            if (_isSpawnedEnemyWithDrop == false)
            {
                int randomIndexOfEnemyCar = Random.Range(0, _poolList.Count);

                EnemyCar newEnemyCar = _poolList[randomIndexOfEnemyCar].GetElement();
                PlaceEnemyCar(newEnemyCar, indexOfSpawnPoint);
            }
            else
            {
                EnemyCarWithDrop newEnemyCarWithDrop = _enemyCarWithDropPool.GetElement();
                PlaceEnemyCar(newEnemyCarWithDrop, indexOfSpawnPoint);

                _isSpawnedEnemyWithDrop = false;
            }
        }
    }

    private void PlaceEnemyCar(EnemyCar enemyCar, int index)
    {
        enemyCar.transform.rotation = Quaternion.identity;
        enemyCar.transform.position = _spawnPoints[index].position;

        _spawnPoints.RemoveAt(index);
    }

    private void SetFlagForSpawnEnemyWithDrop(bool isSpawnedEnemyWithDrop)
    {
        _isSpawnedEnemyWithDrop = isSpawnedEnemyWithDrop;
    }

    private void SetSpawnPoints(Transform spawnPointsContainer)
    {
        _spawnPoints = new List<Transform>();

        for (int i = 0; i < spawnPointsContainer.childCount; i++)
        {
            _spawnPoints.Add(spawnPointsContainer.GetChild(i));
        }
    }
}
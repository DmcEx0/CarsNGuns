using System.Collections.Generic;
using UnityEngine;

public class EnemyCarFactory : GameObjectFactory<EnemyCar>
{
    [SerializeField] private string _poolContainerName;
    [SerializeField] private List<EnemyCar> _enemiesCars;
    [SerializeField] private int _numberOfCarsInPool;

    [SerializeField] private int _minNumberOfEnemyCarOnTrack = 4;
    [SerializeField] private int _maxNumberOfEnemyCarOnTrack = 9;

    private TrackFactory _trackFactory;
    private List<Transform> _spawnPoints;

    private void OnEnable()
    {
        _trackFactory.EnemyCarSpawned += Spawn;
    }

    private void OnDisable()
    {
        _trackFactory.EnemyCarSpawned -= Spawn;
    }

    private void Awake()
    {
        _trackFactory = GetComponent<TrackFactory>(); // сильная связь - плохо
    }

    private void Start()
    {
        foreach (var enemyCar in _enemiesCars)
        {
            CreatePool(GetTemplate(enemyCar), _numberOfCarsInPool, _poolContainerName);
        }
    }

    protected override void Spawn(Transform spawnPointContainer)
    {
        SetSpawnPoints(spawnPointContainer);

        int numberOfEnemiesCars = Random.Range(_minNumberOfEnemyCarOnTrack, _maxNumberOfEnemyCarOnTrack);

        for (int i = 0; i < numberOfEnemiesCars; i++)
        {
            int indexOfSpawnPoint = Random.Range(0, _spawnPoints.Count);

            EnemyCar newEnemyCar = GetElement();

            newEnemyCar.transform.rotation = Quaternion.identity;
            newEnemyCar.transform.position = _spawnPoints[indexOfSpawnPoint].transform.position;

            _spawnPoints.RemoveAt(indexOfSpawnPoint);
        }
    }

    protected override EnemyCar GetTemplate(EnemyCar enemyCar)
    {
        return enemyCar;
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
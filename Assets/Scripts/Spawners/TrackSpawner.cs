using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Events;

public class TrackSpawner : Spawner
{
    [SerializeField] private int _numberOfTrakcsInPool;
    [SerializeField] private PartTrack _firstTrack;

    private List<PartTrack> _spawnedTrack = new List<PartTrack>();
    private ObjectPool<PartTrack> _partTrackPool;

    private int _spawnCount;

    public event UnityAction<Transform> EnemyCarSpawned;
    public event UnityAction<bool> EnemyWithDropSpawned;

    private void Start()
    {
        _partTrackPool = new ObjectPool<PartTrack>(_firstTrack, _numberOfTrakcsInPool);

        _spawnedTrack.Add(_firstTrack);

        _firstTrack.NextTrackSpawned += Spawn;
    }

    protected override void Spawn(Transform spawnPoint)
    {
        int countTrackBetweenSpawnEnemyCarWithDrop = 1;

        PartTrack newTrack = _partTrackPool.GetElement();
        newTrack.NextTrackSpawned += Spawn;
        newTrack.transform.position = _spawnedTrack[_spawnedTrack.Count - 1].EndPoint.position - spawnPoint.localPosition;

        EnemyCarSpawned?.Invoke(newTrack.EnemnySpawnPointsCointainer);

        _spawnedTrack.Add(newTrack);

        _spawnCount++;

        if(_spawnCount % countTrackBetweenSpawnEnemyCarWithDrop == 0)
        {
            EnemyWithDropSpawned?.Invoke(true);
            _spawnCount = 0;
        }

        Despawn();
    }

    private void Despawn()
    {
        int maxQuantityTrackOnScene = 3;
        int firstElementInList = 0;

        if (_spawnedTrack.Count >= maxQuantityTrackOnScene)
        {
            _spawnedTrack[firstElementInList].NextTrackSpawned -= Spawn;
            _spawnedTrack[firstElementInList].gameObject.SetActive(false);
            _spawnedTrack.RemoveAt(firstElementInList);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackSpawner : Spawner
{
    [SerializeField] private PartTrack _firstTrack;

    private List<PartTrack> _spawnedTrack = new List<PartTrack>();

    private ObjectPool<PartTrack> _pool;

    public event UnityAction<Transform> EnemyCarSpawned;

    private void Start()
    {
        _spawnedTrack.Add(_firstTrack);
        _firstTrack.NextTrackSpawned += Spawn;
        CreatePool();
    }

    protected override void Spawn()
    {
        int maxQuantityTrackOnScene = 3;

        PartTrack newTrack = _pool.GetFreeElement();
        newTrack.NextTrackSpawned += Spawn;
        newTrack.transform.position = _spawnedTrack[_spawnedTrack.Count - 1].EndPoint.position - newTrack.StartPoint.localPosition;
        EnemyCarSpawned?.Invoke(newTrack.EnemnySpawnPointsCointainer);

        _spawnedTrack.Add(newTrack);

        if (_spawnedTrack.Count >= maxQuantityTrackOnScene)
        {
            _spawnedTrack[0].NextTrackSpawned -= Spawn;
            _spawnedTrack[0].gameObject.SetActive(false);
            _spawnedTrack.RemoveAt(0);
        };
    }

    protected override void CreatePool()
    {
        base.CreatePool();

        _pool = new ObjectPool<PartTrack>(_firstTrack, PoolCount,Container.transform, IsAutoExpand);
    }
}

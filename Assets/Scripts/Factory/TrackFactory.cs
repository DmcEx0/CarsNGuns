using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrackFactory : GameObjectFactory<PartTrack>
{
    [SerializeField] private string _poolContainerName;
    [SerializeField] private PartTrack _firstTrack;
    [SerializeField] private int _numberOfTrakcsInPool;

    private List<PartTrack> _spawnedTrack = new List<PartTrack>();
    private PartTrack _nextTrack;

    public event UnityAction<Transform> EnemyCarSpawned;

    private void Start()
    {
        CreatePool(_firstTrack ,_numberOfTrakcsInPool, _poolContainerName);

        _spawnedTrack.Add(_firstTrack);

        _firstTrack.NextTrackSpawned += Spawn;
    }

    protected override PartTrack GetTemplate(PartTrack track)
    {
        return _firstTrack;
    }

    protected override void Spawn(Transform spawnPoint)
    {
        PartTrack newTrack = GetElement();
        _nextTrack = newTrack;
        _nextTrack.NextTrackSpawned += Spawn; 
        _nextTrack.transform.position = _spawnedTrack[_spawnedTrack.Count - 1].EndPoint.position - spawnPoint.localPosition;

        EnemyCarSpawned?.Invoke(newTrack.EnemnySpawnPointsCointainer);

        _spawnedTrack.Add(newTrack);

        TrackDespawn();
    }

    private void TrackDespawn()
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

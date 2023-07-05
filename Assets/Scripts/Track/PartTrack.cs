using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class PartTrack : MonoBehaviour
{
    [SerializeField] private Transform _enemnySpawnPointsCointainer;

    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _endPoint;

    public Transform EndPoint => _endPoint;
    public Transform EnemnySpawnPointsCointainer => _enemnySpawnPointsCointainer;

    public event UnityAction<Transform> NextTrackSpawned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerCar>(out PlayerCar player))
        {
            NextTrackSpawned?.Invoke(_startPoint);
        }
    }
}
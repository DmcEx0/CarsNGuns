using UnityEngine;
using UnityEngine.Events;

public class PlayerCarSpawner : Spawner
{
    [Header("Car")]
    //[SerializeField] private CameraManager _cameraManager;
    [SerializeField] private Transform _carSpawnPoint;
    [SerializeField] private GameObject _playerControllerRoot;

    private PlayerCar _playerCar;

    public event UnityAction<Transform> PlayerSpawned;

    public void ChooseCar(PlayerCar car)
    {
        _playerCar = car;
        Spawn(_carSpawnPoint);
    }

    protected override void Spawn(Transform spawnPoint)
    {
        PlayerCar playerCar = Instantiate(_playerCar, spawnPoint.position, Quaternion.identity);
        //playerCar.SetCurrentWeapon(_weaponSpawner.GetWeaponData(spawnPoint));
        PlayerCarMovement playerCarMovement = playerCar.GetComponent<PlayerCarMovement>();
        playerCarMovement.SetControllerRoot(_playerControllerRoot);

        PlayerSpawned?.Invoke(playerCar.WeaponPosition);
        //_cameraManager.SetTartget(playerCar);
    }
}
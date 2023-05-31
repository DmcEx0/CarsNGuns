using UnityEngine;

public class PlayerCarFactory : GameObjectFactory<PlayerCar>
{
    [Header("Car")]
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private Transform _carSpawnPoint;

    private BulletFactory _bulletSpawner;

    private PlayerCar _playerCar;

    private void Start()
    {
        _bulletSpawner = GetComponent<BulletFactory>();
    }

    protected override void Spawn(Transform spawnPoint)
    {
        PlayerCar playerCar = GetElement();
        playerCar.transform.position = spawnPoint.position;

        _bulletSpawner.SetPlayerCar(playerCar);
        _cameraManager.SetTartget(playerCar);
    }

    public void ChooseCar(PlayerCar car)
    {
        _playerCar = car;
        //_bulletSpawner.SetPlayerCar(_playerCar);
        Spawn(_carSpawnPoint);
    }

    protected override PlayerCar GetTemplate(PlayerCar playerCar)
    {
        return _playerCar;
    }
}

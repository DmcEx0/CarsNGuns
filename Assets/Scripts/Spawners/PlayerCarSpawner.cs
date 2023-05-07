using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarSpawner : Spawner
{
    [Header("Car")]
    [SerializeField] private CameraManager _cameraManager;
    [SerializeField] private Transform _carSpawnPont;

    private PlayerCar _playerCar;

    protected override void Spawn()
    {
        PlayerCar playerCar = Instantiate(_playerCar, _carSpawnPont.position, Quaternion.identity);
        _cameraManager.SetTartget(playerCar);
    }

    public void ChooseCar(PlayerCar car)
    {
        _playerCar = car;
        Spawn();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarWithDropSpawner : Spawner
{
    [SerializeField] private EnemyCarWithDrop _enemyCarWithDrop;

    private WeaponSpawner _weaponSpawner;
    private PlayerCarSpawner _playerCarSpawner;

    private void Awake()
    {
        _weaponSpawner = GetComponent<WeaponSpawner>();
        _playerCarSpawner = GetComponent<PlayerCarSpawner>();
    }

    public void SpawnEnemyCarWithDrop(Transform spawnPoint)
    { 
        //CreateObject(spawnPoint);
    }

    protected override void Spawn(Transform spawnPoint)
    {
        //EnemyCarWithDrop enemyCarWithDrop = GetElement();
        //enemyCarWithDrop.SetWeaponDropping(_weaponSpawner.GetWeaponData());

        //enemyCarWithDrop.transform.position = spawnPoint.position;
        //enemyCarWithDrop.transform.rotation = Quaternion.identity;

        //enemyCarWithDrop.Died += OnEnemyCarDie;
    }


    private void OnEnemyCarDie(Car car)
    {
        EnemyCarWithDrop newCar = (EnemyCarWithDrop)car;

        newCar.Died -= OnEnemyCarDie;


    }
}
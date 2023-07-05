using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : Spawner
{
    [SerializeField] private List<WeaponData> _weaponsData;
    [SerializeField] private WeaponData _defaultWeaponData;
    [SerializeField] private int _numberOfWeaponInPool;

    private ObjectPool<Weapon> _weaponPool;
    private List<ObjectPool<Weapon>> _poolList;

    private WeaponData _currentWeaponData;

    private PlayerCarSpawner _playerCarSpawner;

    private void OnEnable()
    {
        _playerCarSpawner.PlayerSpawned += Spawn;
    }

    private void OnDisable()
    {
        _playerCarSpawner.PlayerSpawned -= Spawn;


    }

    private void Awake()
    {
        _playerCarSpawner = GetComponent<PlayerCarSpawner>();
    }

    private void Start()
    {
        _poolList = new List<ObjectPool<Weapon>>();

        for (int i = 0; i < _weaponsData.Count; i++)
        {
            _weaponPool = new ObjectPool<Weapon>(_weaponsData[i].WeaponPrefab, _numberOfWeaponInPool);
            _poolList.Add(_weaponPool);
        }
    }

    public Weapon GetWeaponData(Transform spawnPoint)
    {
        int randomIndex = Random.Range(0, _weaponsData.Count);
        _currentWeaponData = _weaponsData[randomIndex];
        Spawn(spawnPoint);

        return _currentWeaponData.WeaponPrefab;
    }

    protected override void Spawn(Transform spawnPoint)
    {
        //for (int i = 0; i < _poolList.Count; i++)
        //{
        //    if (_poolList[i].GetElement() == _currentWeaponData.WeaponPrefab)
        //    {
        //        Weapon newWeapon = _poolList[i].GetElement();
        //        newWeapon.Initialize(_currentWeaponData);

        //        newWeapon.transform.position = spawnPoint.position;
        //        newWeapon.transform.rotation = Quaternion.identity;
        //        newWeapon.transform.SetParent(spawnPoint);
        //    }
        //}
        Weapon defaultWeapon = Instantiate(_defaultWeaponData.WeaponPrefab, spawnPoint);

        defaultWeapon.Initialize(_defaultWeaponData);
        defaultWeapon.transform.position = spawnPoint.position;
        defaultWeapon.transform.rotation = Quaternion.identity;

        StartCoroutine(defaultWeapon.TakeShot());
    }
}
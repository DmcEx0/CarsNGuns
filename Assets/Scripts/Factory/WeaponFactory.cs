using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : GameObjectFactory<Weapon>
{
    [SerializeField] private string _poolContainerName;
    [SerializeField] private List<WeaponData> _weaponsData;
    [SerializeField] private int _numberOfWeaponInPool;

    private void Start()
    {
        foreach (var weaponData in _weaponsData)
        {
            CreatePool(GetTemplate(weaponData.WeaponPrefab), _numberOfWeaponInPool, _poolContainerName);
        }
    }

    protected override Weapon GetTemplate(Weapon element)
    {
        return element;
    }

    protected override void Spawn(Transform spawnPoint)
    {
        Weapon weapon = GetElement();

    }
}

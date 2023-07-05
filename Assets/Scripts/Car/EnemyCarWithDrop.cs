using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarWithDrop : EnemyCar
{
    private WeaponData _weaponData;//???

    public void SetWeaponDropping(WeaponData weaponData)
    {
        _weaponData = weaponData;
        Debug.Log(_weaponData);
    }
}
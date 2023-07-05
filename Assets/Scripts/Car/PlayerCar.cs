using System.Collections;
using UnityEngine;

public class PlayerCar : Car
{
    [SerializeField] private Transform _weaponPosition;

    private Weapon _currentWeapon;
    private WaitForSeconds _delay;
    private Coroutine _coroutine;

    public Transform WeaponPosition => _weaponPosition;

    public void SetCurrentWeapon(Weapon weapon)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _currentWeapon = weapon;
    }
}
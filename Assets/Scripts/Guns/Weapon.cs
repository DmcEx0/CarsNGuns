using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;

    private float _damagePerAttack;
    private float _bulletSpeed;

    public float AttackRatio { get; private set; }
    public Bullet Bullet { get; private set; }

    public void Initialize(WeaponData weaponData)
    {
        AttackRatio = weaponData.AttackRatio;
        _damagePerAttack = weaponData.DamagePerAttack;
        _bulletSpeed = weaponData.BulletSpeed;
        Bullet = weaponData.BulletPrefab;
    }

    public void TakeShot()
    {
       var bullet = Instantiate(Bullet, _shotPoint.position, Quaternion.Euler(90, 0, 0));
        bullet.Initialize(_bulletSpeed, _damagePerAttack);
    }
}
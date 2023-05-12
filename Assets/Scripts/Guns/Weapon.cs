using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;

    private Bullet _bullet;
    private float _attackRatio;
    private float _damagePerAttack;
    private float _bulletSpeed;

    public void Initialize(WeaponData weaponData)
    {
        _attackRatio = weaponData.AttackRatio;
        _damagePerAttack = weaponData.DamagePerAttack;
        _bulletSpeed = weaponData.BulletSpeed;
        _bullet = weaponData.BulletPrefab;
    }

    public void TakeShot()
    {
       var bullet = Instantiate(_bullet, _shotPoint.position, Quaternion.identity);
        bullet.Initialize(_bulletSpeed);
    }
}
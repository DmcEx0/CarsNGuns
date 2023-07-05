using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;

    private ObjectPool<Bullet> _bulletPool;
    private int _numberOfBulletInPool;

    private float _attackRatio;

    private float _bulletDamage;
    private float _bulletSpeed;

    public Bullet Bullet { get; private set; }

    public void Initialize(WeaponData weaponData)
    {
        _attackRatio = weaponData.AttackRatio;
        _bulletDamage = weaponData.DamagePerAttack;
        _bulletSpeed = weaponData.BulletSpeed;
        Bullet = weaponData.BulletPrefab;
        _numberOfBulletInPool = weaponData.NumberOfBulletInPool;

        _bulletPool = new ObjectPool<Bullet>(Bullet, _numberOfBulletInPool);
    }

    public IEnumerator TakeShot()
    {
        while (gameObject.activeInHierarchy == true)
        {
            Bullet newBullet = _bulletPool.GetElement();
            newBullet.Initialize(_bulletSpeed, _bulletDamage);
            newBullet.transform.position = _shotPoint.position;
            newBullet.transform.rotation = Quaternion.Euler(0f, 90f, 90f);

            yield return new WaitForSeconds(_attackRatio);
        }
    }
}
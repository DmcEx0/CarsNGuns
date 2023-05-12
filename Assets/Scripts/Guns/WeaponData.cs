using UnityEngine;

[CreateAssetMenu(fileName = "NewGun", menuName = "CarRacing/WeaponData", order = 51)]
public class WeaponData : ScriptableObject
{
    [Header("Common")]
    [SerializeField] private Weapon _weaponPrefab;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private TypeDamage _typeDamage;

    [Header("Personal")]
    [SerializeField] private float _attackRatio;
    [SerializeField] private float _damagePerAttack;
    [SerializeField] private float _bulletSpeed;

    private enum TypeDamage
    {
        Bullet,
        Fire,
        Electric,
        Laser
    }

    public Weapon WeaponPrefab => _weaponPrefab;
    public Bullet BulletPrefab => _bulletPrefab;
    public float AttackRatio => _attackRatio;
    public float DamagePerAttack => _damagePerAttack;
    public float BulletSpeed => _bulletSpeed;
}

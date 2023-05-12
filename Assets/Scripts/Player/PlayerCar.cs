using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerCar : MonoBehaviour
{
    [SerializeField] private WeaponData _defaultWeapon;
    [SerializeField] private Transform _weaponPosition;

    private Weapon _currentWeapon;

    private void Start()
    {
        SetWeapon(_defaultWeapon);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _currentWeapon.TakeShot();
        }
    }

    public void SetWeapon(WeaponData weaponData)
    {
        if (_currentWeapon != null)
            Destroy(_currentWeapon.gameObject);

        _currentWeapon = Instantiate(weaponData.WeaponPrefab, _weaponPosition.position, transform.rotation, transform);
        _currentWeapon.Initialize(weaponData);
    }
}
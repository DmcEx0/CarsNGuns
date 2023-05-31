using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerCar : MonoBehaviour
{
    [SerializeField] private WeaponData _defaultWeapon;
    [SerializeField] private Transform _weaponPosition;

    public Weapon CurrentWeapon { get; private set; }

    private WaitForSeconds _delay;

    private void Start()
    {
        SetWeapon(_defaultWeapon);

        _delay = new WaitForSeconds(CurrentWeapon.AttackRatio);
    }

    public void SetWeapon(WeaponData weaponData)
    {
        if (CurrentWeapon != null)
            Destroy(CurrentWeapon.gameObject);

        CurrentWeapon = Instantiate(weaponData.WeaponPrefab, _weaponPosition.position, transform.rotation, transform);
        CurrentWeapon.Initialize(weaponData);

        //StartCoroutine(TakeShots());
    }

    private IEnumerator TakeShots()
    {
        while (CurrentWeapon != null) //пока игрок не умрет
        {
            CurrentWeapon.TakeShot();

            yield return _delay;
        }
    }
}
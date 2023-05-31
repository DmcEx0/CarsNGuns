using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCar : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    private WeaponData _weaponData;

    private float _minHealth = 0f;
    private float _currentHealth;

    public event UnityAction Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);

        if(_currentHealth <= 0 )
        {
            gameObject.SetActive(false);
            _currentHealth = _maxHealth;
            Died?.Invoke();
        }
    }

    public void SetWeaponDropping(WeaponData weaponData)
    {
        _weaponData = weaponData;
    }
}

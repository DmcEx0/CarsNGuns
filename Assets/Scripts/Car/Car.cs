using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public abstract class Car : MonoBehaviour
{
    [SerializeField] private float _defaultHealth;

    private readonly float _minHealth = 0f;
    private float _currentHealth;

    public event UnityAction<Car> Died;

    private void OnEnable()
    {
        _currentHealth = _defaultHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _defaultHealth);
        TryDie();
    }

    private void TryDie()
    {
        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
            Died?.Invoke(this);
        }
    }
}
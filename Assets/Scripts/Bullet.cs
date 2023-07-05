using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime = 4;

    private float _defaultMoveSpeed;
    private float _damage;
    private Rigidbody _rb;

    private float _currentTime = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _lifetime)
        {
            gameObject.SetActive(false);
            _currentTime = 0;
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Vector3.forward * _defaultMoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCar>(out EnemyCar enemyCar))
        {
            enemyCar.TakeDamage(_damage);

            gameObject.SetActive(false);
        }
    }

    public void Initialize(float moveSpeed, float damage)
    {
        _defaultMoveSpeed = moveSpeed;
        _damage = damage;
    }
}
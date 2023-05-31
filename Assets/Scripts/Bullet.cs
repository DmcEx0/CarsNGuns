using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _defaultMoveSpeed;
    private float _damage;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + Vector3.forward * _defaultMoveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyCar>(out EnemyCar enemyCar))
        {
            enemyCar.ApplyDamage(_damage);

            gameObject.SetActive(false);
        }
    }

    public void Initialize(float moveSpeed, float damage)
    {
        _defaultMoveSpeed = moveSpeed;
        _damage = damage;
    }
}

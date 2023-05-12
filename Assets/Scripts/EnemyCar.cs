using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private Rigidbody _rb;
    private int _moveSpeed;

    private void Start()
    {
        int minMoveSpeed = 13;
        int maxMoveSpeed = 15;

        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _rb.transform.forward * _moveSpeed * Time.fixedDeltaTime);
    }
}

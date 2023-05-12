using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _defaultMoveSpeed;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + transform.forward * _defaultMoveSpeed * Time.fixedDeltaTime);
    }

    public void Initialize(float moveSpeed)
    {
        _defaultMoveSpeed = moveSpeed;
    }
}

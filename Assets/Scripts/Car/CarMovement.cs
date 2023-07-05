using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public abstract class CarMovement : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 1.5f;
    [SerializeField] private float _turnAngle = 25f;
    [SerializeField] private Rigidbody _rb;

    protected void Move(float speed)
    {
        _rb.MovePosition(_rb.position + new Vector3(_rb.transform.forward.x, 0, _rb.transform.forward.z) * speed * Time.fixedDeltaTime);
    }

    protected void Rotate(Vector3 direction)
    {
        _rb.MoveRotation(Quaternion.Lerp(_rb.transform.rotation, Quaternion.Euler(0f, direction.x * _turnAngle, 0f), _rotateSpeed * Time.fixedDeltaTime));
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarMovement : MonoBehaviour
{
    [SerializeField] private float _defaultMoveSpeed = 25f;
    [SerializeField] private float _rotateSpeed = 1.5f;
    [SerializeField] private float _turnAngle = 45f;

    private PlayerController _playerController;
    private Rigidbody _rb;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate(new Vector3(_playerController.MoveDirection.x, 0, _playerController.MoveDirection.y));
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _rb.transform.forward * _defaultMoveSpeed * Time.fixedDeltaTime);
    }

    private void Rotate(Vector3 direction)
    {
        _rb.MoveRotation(Quaternion.Lerp(_rb.transform.rotation, Quaternion.Euler(0f, direction.x * _turnAngle, 0f), _rotateSpeed * Time.fixedDeltaTime));
    }
}

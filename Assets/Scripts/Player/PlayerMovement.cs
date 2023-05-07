using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _defaultMoveSpeed = 25f;

    private PlayerController _playerController;
    private Rigidbody _rb;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _rb.transform.forward * _defaultMoveSpeed * Time.fixedDeltaTime);
    }
}

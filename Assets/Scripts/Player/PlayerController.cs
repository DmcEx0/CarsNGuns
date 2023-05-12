using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;

    private Vector3 _moveDirection;

    public Vector3 MoveDirection => _moveDirection;

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void Update()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
    }
}

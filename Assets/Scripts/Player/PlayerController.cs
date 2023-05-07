using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CameraManager _cameraManager;

    private PlayerCar _player;
    private PlayerInput _playerInput;

    private Vector3 _moveDirection;

    public Vector3 LookDirection => _moveDirection;

    public CameraManager CameraManager => _cameraManager;

    private void OnEnable()
    {
        _playerInput.Enable();
        //_playerInput.Player.TakeShot.performed += ctx => _player.CurrentWeapon?.TakeShot();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        //_playerInput.Player.TakeShot.performed -= ctx => _player.CurrentWeapon?.TakeShot();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _player = GetComponent<PlayerCar>();
    }

    private void Update()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();
    }
}

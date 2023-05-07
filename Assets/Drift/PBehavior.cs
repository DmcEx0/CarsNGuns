using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PBehavior : MonoBehaviour
{
    //[Header("Car Settings")]
    //[Range(0f, 1f)]
    //[SerializeField] private float _smoothingRotation = 0.5f;
    //[SerializeField] private float _defaultMoveSpeed = 25f;

    //[Header("Drift Settings")]
    //[SerializeField] private float _driftSpeedLoss = 0.2f;
    //[SerializeField] private float _driftForce = 20f;
    //[SerializeField] private float _minAngleForDrift = 60f;

    //private PlayerController _playerController;
    //private Rigidbody _rb;

    //private Vector3 _mousePosition;
    //private bool _isDrifting;
    //private float _angleDrift;
    //private float _lookAngleVelocity;
    //private float _currentMoveSpeed;

    //private void Start()
    //{
    //    _playerController = GetComponent<PlayerController>();
    //    _rb = GetComponent<Rigidbody>();

    //    _currentMoveSpeed = _defaultMoveSpeed;
    //}

    //private void Update()
    //{
    //    _currentMoveSpeed = _defaultMoveSpeed;
    //    Vector3 direction = _mousePosition;

    //    _angleDrift = Vector3.Angle(_rb.transform.forward, direction);

    //    if (_angleDrift > _minAngleForDrift)
    //    {
    //        _isDrifting = true;
    //        _currentMoveSpeed -= _driftSpeedLoss * Time.fixedDeltaTime;

    //    }
    //    else
    //    {
    //        _isDrifting = false;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    RotatePlayerTowardsMousePointer();

    //    if (_isDrifting)
    //    {
    //        Quaternion rotation = Quaternion.AngleAxis(_angleDrift - 90f, Vector3.up);
    //        Vector3 driftForceVector = rotation * _rb.transform.forward * _driftForce * Time.fixedDeltaTime;
    //        _rb.AddRelativeTorque((driftForceVector * 2) * Mathf.Lerp(1.5f, .5f, _currentMoveSpeed / 100f), ForceMode.Acceleration);
    //        Debug.Log(_currentMoveSpeed);
    //    }
    //}

    //private void RotatePlayerTowardsMousePointer()
    //{
    //    Vector3 cursorePosition = new Vector3(_playerController.LookDirection.x, _playerController.LookDirection.y, 0);
    //    Vector3 cameraPosition = _playerController.CameraManager.transform.position;
    //    Vector3 mousePositionOnPlayerPlane = cameraPosition;

    //    mousePositionOnPlayerPlane.y = transform.position.y;

    //    Plane playerPlane = new Plane(Vector3.up, transform.position);

    //    Ray ray = Camera.main.ScreenPointToRay(cursorePosition);

    //    float distance = 0f;

    //    if (playerPlane.Raycast(ray, out distance))
    //    {
    //        mousePositionOnPlayerPlane = ray.GetPoint(distance);
    //    }

    //    Vector3 lookDirection = mousePositionOnPlayerPlane - transform.position;
    //    lookDirection.y = 0f;

    //    _mousePosition = lookDirection;

    //    Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
    //    float smoothLookAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, lookRotation.eulerAngles.y, ref _lookAngleVelocity, _smoothingRotation);
    //    _rb.rotation = Quaternion.Euler(0, smoothLookAngle, 0);

    //    _rb.MovePosition(_rb.position + _rb.transform.forward * _currentMoveSpeed * Time.fixedDeltaTime);
    //}
}

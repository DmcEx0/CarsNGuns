using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private CinemachineVirtualCamera _camera;

    private void Start()
    {
        _camera = GetComponent<CinemachineVirtualCamera>();
    }

    public void SetTartget(PlayerCar target)
    {
        _camera.LookAt = target.transform;
        _camera.Follow = target.transform;
    }
}

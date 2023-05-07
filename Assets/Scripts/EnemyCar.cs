using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    private Rigidbody _rb;
    private int _moveSpeed;

    private void Start()
    {
        int minMoveSpeed = 10;
        int maxMoveSpeed = 21;

        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.MovePosition(_rb.position + transform.forward * _moveSpeed * Time.deltaTime);
    }
}

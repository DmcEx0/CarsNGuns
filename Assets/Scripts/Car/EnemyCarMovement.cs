using UnityEngine;

public class EnemyCarMovement : CarMovement
{
    private float _moveSpeed;

    private void Start()
    {
        float minMoveSpeed = 13;
        float maxMoveSpeed = 15;

        _moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
    }

    void FixedUpdate()
    {
        Move(_moveSpeed);
        Rotate(Vector3.forward);
    }
}
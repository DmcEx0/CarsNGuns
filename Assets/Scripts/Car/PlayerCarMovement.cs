using UnityEngine;

public class PlayerCarMovement : CarMovement
{
    [SerializeField] private float _defaultMoveSpeed = 25f;

    private PlayerController _playerController;
    private GameObject _playerControllerRoot;

    private float _currentMoveSpeed;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _currentMoveSpeed = _defaultMoveSpeed;
    }

    private void Update()
    {
        MovePlayerControllerRoot();
    }

    private void FixedUpdate()
    {
        Move(_currentMoveSpeed);
        Rotate(new Vector3(_playerController.MoveDirection.x, 0, _playerController.MoveDirection.y));
    }

    public void SetControllerRoot(GameObject controllerRoot)
    {
        _playerControllerRoot = controllerRoot;
    }

    private void MovePlayerControllerRoot()
    {
        if( _playerControllerRoot != null )
        {
            _playerControllerRoot.transform.position = new Vector3(0f, 0f, this.transform.position.z);
        }
    }
}
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _playerMovement.Move(Vector2.left);
            _playerMovement.Flip();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _playerMovement.Move(Vector2.right);
            _playerMovement.NotFlip();
        }

        if (Input.GetKey(KeyCode.Space))
            _playerMovement.Jump();   
    }
}

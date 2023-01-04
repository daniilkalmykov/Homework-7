using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    private const float DistanceBetweenPlayerAndGround = 0.05f;
    
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    
    private readonly int _speedAnimatorParameter = Animator.StringToHash("Speed");
    private readonly int _isJumpingAnimatorParameter = Animator.StringToHash("IsJumping");

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private bool _onGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down, DistanceBetweenPlayerAndGround, _ground);
        _onGround = hit;

        _animator.SetFloat(_speedAnimatorParameter, _rigidbody.velocity.magnitude);
    }

    public void Move(Vector3 direction)
    {
        Vector2 velocity = new Vector2(direction.x * _speed, _rigidbody.velocity.y);

        _rigidbody.velocity = velocity;
    }

    public void Jump()
    {
        if (_onGround)
        {
            _rigidbody.velocity = Vector2.up * _jumpSpeed;
            
            _onGround = false;
            
            _animator.SetTrigger(_isJumpingAnimatorParameter);
            _animator.SetFloat(_speedAnimatorParameter, 0);
        }
    }

    public void Flip()
    {
        _spriteRenderer.flipX = true;
    }

    public void NotFlip()
    {
        _spriteRenderer.flipX = false;
    }
}

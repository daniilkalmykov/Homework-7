using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyTrigger[] _points;
    [SerializeField] private float _delay;
    [SerializeField] private float _speed;

    private readonly int _speedAnimatorParameter = Animator.StringToHash("Speed");
    
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _target;
    private float _timer;
    private float _startSpeed;
    private int _currentTarget;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _currentTarget = 0;
        _target = _points[_currentTarget].transform.position;

        _startSpeed = _speed;
        
        _animator.SetFloat(_speedAnimatorParameter, _speed);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    public void Reach()
    {
        StartCoroutine(StayInTrigger());
        _speed = 0;
           
        _animator.SetFloat(_speedAnimatorParameter, _speed);
    }

    private IEnumerator StayInTrigger()
    {
        yield return new WaitForSeconds(_delay);

        if (_currentTarget < _points.Length - 1)
            _currentTarget++;
        else
            _currentTarget = 0;

        _target = _points[_currentTarget].transform.position;

        _spriteRenderer.flipX = !_spriteRenderer.flipX;
        
        _speed = _startSpeed;
        _animator.SetFloat(_speedAnimatorParameter, _speed);
    }
}
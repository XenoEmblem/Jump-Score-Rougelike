using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject _pointA;
    [SerializeField] private GameObject _pointB;
    [SerializeField] float _speed = 1f; 
    
    Rigidbody2D _rigidbody;
    Animator _animator;
    private Transform _currentPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentPoint = _pointA.transform;
        _animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = _currentPoint.position -  transform.position;
        if (_currentPoint == _pointB.transform)
        {
            _rigidbody.linearVelocity = new Vector2(_speed, 0);
        }
        else
        {
            _rigidbody.linearVelocity = new Vector2(-_speed, 0);
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) > 0.1f && _currentPoint == _pointB.transform)
        {
            _currentPoint = _pointB.transform;
        }

        if (Vector2.Distance(transform.position, _currentPoint.position) > 0.1f && _currentPoint == _pointA.transform)
        {
            _currentPoint = _pointA.transform;
        }
    }
}

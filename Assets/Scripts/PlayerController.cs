using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action OnJump;

    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _jumpSpeed = 10f;
    [SerializeField] float _extraGravity = 700f;
    [SerializeField] float _maxFallSpeed = -25f;
    [SerializeField] float _gravityDelay = .2f;
    [SerializeField] float _coyoteTime = .2f;

    PlayerInput _playerInput;
    FrameInput _frameInput;
    Rigidbody2D _rigidbody;
    BoxCollider2D _footCollider;
    CapsuleCollider2D _bodyCollider;
    Animator _animator;
    float _timeInAir, _coyoteTimer;
    Upgrades _upgrades;

    void OnEnable()
    {
        OnJump += ApplyJumpForce;
    }

    void OnDisable()
    {
        OnJump -= ApplyJumpForce;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _footCollider = GetComponent<BoxCollider2D>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _upgrades = GetComponent<Upgrades>();
    }

    void Update()
    {
        GatherInput();
        Run();
        FlipSprite();
        CoyoteTimer();
        HandleJump();
        GravityDelay();
    }

    void FixedUpdate()
    {
        ExtraGravity();
    }

    void GatherInput()
    {
        _frameInput = _playerInput.FrameInput;
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(_frameInput.Move.x * _moveSpeed, _rigidbody.linearVelocity.y);
        _rigidbody.linearVelocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody.linearVelocity.x) > Mathf.Epsilon;
        _animator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody.linearVelocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody.linearVelocity.x), 1f);
    }

    void HandleJump()
    {
        if (!_frameInput.Jump) return;
        if (_footCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            OnJump?.Invoke();
        }
        else if (_coyoteTimer > 0f)
        {
            OnJump?.Invoke();
        }
    }

    void ApplyJumpForce()
    {
        _rigidbody.linearVelocity = Vector2.zero;
        _timeInAir = 0f;
        _coyoteTimer = 0f;
        _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        //_rigidbody.linearVelocity += new Vector2(0f, _jumpSpeed);
    }

    void GravityDelay()
    {
        if (!_footCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _timeInAir += Time.deltaTime;
        }
        else
        {
            _timeInAir = 0f;
        }
    }

    void ExtraGravity()
    {
        if (_timeInAir > _gravityDelay)
        {
            _rigidbody.AddForce(new Vector2(0f, -_extraGravity* Time.deltaTime));
            if (_rigidbody.linearVelocity.y < _maxFallSpeed)
            {
                _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _maxFallSpeed);
            }
        }
    }

    void CoyoteTimer()
    {
        if (_footCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _coyoteTimer = _coyoteTime;
        }
        else
        {
            _coyoteTimer -= Time.deltaTime;
        }
    }
    
    
    
}
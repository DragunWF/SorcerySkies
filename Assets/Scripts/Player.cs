using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private bool _isFacingRight = true;
    private int _speed = 5;
    private Vector2 _rawInput;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _collider;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        Move();
    }

    private void OnMove(InputValue value)
    {
        _rawInput = value.Get<Vector2>();
    }

    private void OnJump()
    {

    }

    private void FlipSprite(bool isMoving)
    {
        if (isMoving)
        {
            float inputValue = Mathf.Sign(_rawInput.x);
            _isFacingRight = inputValue >= 1;
            transform.localScale = new Vector2(inputValue, 1);
        }
    }

    private void Move()
    {
        float speed = _rawInput.x * _speed;

        Vector2 playerVelocity = new Vector2(speed, _rigidbody.velocity.y);
        _rigidbody.velocity = playerVelocity;

        _animator.SetBool("Moving", Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon);
        FlipSprite(Mathf.Abs(speed) > Mathf.Epsilon);
    }
}

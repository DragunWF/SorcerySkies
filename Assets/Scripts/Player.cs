using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class Player : MonoBehaviour
{
    private int _lives = 2;
    private bool _isDamageCooldown = false;

    private bool _isFacingRight = true;
    private float _speed = 5;
    private float _jumpForce = 11.5f;
    private Vector2 _rawInput;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;

    private MainSceneUI _mainSceneUI;
    private AudioPlayer _audioPlayer;
    private ParticlePlayer _particlePlayer;
    private FadeToBlack _sceneTransition;

    public void DamagePlayer()
    {
        if (!_isDamageCooldown)
        {
            _lives--;
            _mainSceneUI.UpdateLivesText(_lives);
            if (_lives == 1)
            {
                // change sprite to spider
            }
            else if (_lives <= 0)
            {
                Death();
                return;
            }
            _audioPlayer.PlayDamage();
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();

        _mainSceneUI = FindObjectOfType<MainSceneUI>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _particlePlayer = FindObjectOfType<ParticlePlayer>();
        _sceneTransition = FindObjectOfType<FadeToBlack>();
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
        if (_collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            _rigidbody.velocity += new Vector2(_rigidbody.velocity.x, _jumpForce);
            _audioPlayer.PlayJump();
        }
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

    private void Death()
    {
        _audioPlayer.PlayDeath();
        _particlePlayer.PlayDeath(transform.position);
        _sceneTransition.InitializeFade();
        gameObject.SetActive(false);
    }
}

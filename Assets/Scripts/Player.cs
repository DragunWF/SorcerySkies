using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class Player : MonoBehaviour
{
    private int _lives = 2;
    private bool _isDamageCooldown = false;
    private const float _damageCooldownTime = 1.5f;

    private bool _isFacingRight = true;
    private float _speed = 5;
    private float _jumpForce = 11.5f;
    private Vector2 _rawInput;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private FlashEffect _flashEffect;

    private MainSceneUI _mainSceneUI;
    private AudioPlayer _audioPlayer;
    private ParticlePlayer _particlePlayer;
    private FadeToBlack _sceneTransition;
    private GameState _gameState;

    #region Getter Methods

    public float GetDamageCooldown() => _damageCooldownTime;

    #endregion

    public void DamagePlayer()
    {
        if (!_isDamageCooldown)
        {
            _lives--;
            _flashEffect.Flash();
            _mainSceneUI.UpdateLivesText(_lives);
            _audioPlayer.PlayDamage();
            if (_lives == 1)
            {
                // change sprite to spider
            }
            else if (_lives <= 0)
            {
                Death();
                return;
            }
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        _flashEffect = GetComponent<FlashEffect>();

        _mainSceneUI = FindObjectOfType<MainSceneUI>();
        _audioPlayer = FindObjectOfType<AudioPlayer>();
        _particlePlayer = FindObjectOfType<ParticlePlayer>();
        _sceneTransition = FindObjectOfType<FadeToBlack>();
        _gameState = FindObjectOfType<GameState>();
    }

    private void Start()
    {
        _gameState.StartState();
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

        _gameState.StopScore();
        _gameState.SaveScore();

        _sceneTransition.InitializeFade();
        gameObject.SetActive(false);
    }
}

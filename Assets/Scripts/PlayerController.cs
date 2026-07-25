using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed = 5f;
    private float _jumpForce = 10f;
    private Vector2 _moveInput;

    private PlayerInput _playerInput;
    private CharacterData _characterData;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _characterData = GetComponent<CharacterData>();
    }

    public void LoadConfig(PlayerConfigSO config)
    {
        if (config == null) return;

        _moveSpeed = config.moveSpeed;
        _jumpForce = config.jumpForce;
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveInput.x * _moveSpeed, _rb.linearVelocity.y);
    }

    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed && IsGrounded())
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
            _characterData.ScoreUp(5);
        }
    }

    private bool IsGrounded()
    {
        return transform.position.y <= 0.1f;
    }
}
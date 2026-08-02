using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed = 5f;
    private float _jumpForce = 10f;
    private float _speedMod = 0;

    private Vector2 _moveInput;

    private PlayerInput _playerInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = new Vector2(_moveInput.x * (_moveSpeed + _speedMod), _rb.linearVelocity.y);
    }

    /// <summary>
    /// Загрузка конфигураций скорости и высоты прыжка
    /// </summary>
    /// <param name="config"></param>
    public void LoadConfig(PlayerConfigSO config)
    {
        if (config == null) return;

        _moveSpeed = config.moveSpeed;
        _jumpForce = config.jumpForce;
    }

    /// <summary>
    /// Загрузка модификатора скорости.
    /// Здесь и вправду нужени ограничители максимального и минимального модификатора, которые могут изменятся при поднятии уровня.
    /// </summary>
    /// <param name="speedMod"></param>
    public void LoadSpeedMod(float speedMod)
    {
        _speedMod = speedMod;
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
        }
    }

    private bool IsGrounded()
    {
        return transform.position.y <= 0.1f;
    }
}
using DG.Tweening;
using Leon.Core.InputActions;
using Leon.Core.Singleton;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Singleton<PlayerController>
{
    [Header("References")]
    [SerializeField] private SphereCollider _coinCollector;

    [Header("States")]
    public bool canRun = false;
    public bool invincible = false;

    [Header("Speed")]
    public float forwardSpeed = 8.0f;
    public float sideSpeed = 0.1f;

    private PlayerInputActions _playerControls;
    private InputAction _tapOn;
    private InputAction _tapOff;
    private InputAction _screenPos;

    private Vector2 _mousePos;
    private Vector3 _startPos;
    private float _currentSpeed;
    private float _regularCoinCollectorRadius;

    #region INPUTS / AWAKE
    protected override void Awake()
    {
        base.Awake();
        _playerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _tapOn = _playerControls.Player.tapOn; _tapOn.Enable();
        _tapOff = _playerControls.Player.tapOff; _tapOff.Enable();
        _screenPos = _playerControls.Player.screenPosition; _screenPos.Enable();
    }
    private void OnDisable()
    {
        _tapOn.Disable();
        _tapOff.Disable();
        _screenPos.Disable();
    }
    #endregion

    private void Start()
    {
        _startPos = transform.position;
        _regularCoinCollectorRadius = _coinCollector.radius;
        ResetSpeed();
    }
    void Update()
    {
        if (!canRun) return;

        ForwardMovement();
        if (_tapOn.IsPressed())
        {
            SideMovement(_screenPos.ReadValue<Vector2>().x - _mousePos.x);
        }

        _mousePos = _screenPos.ReadValue<Vector2>();
    }
    private void SideMovement(float speed)
    {
        transform.Translate(sideSpeed * speed * Time.deltaTime * transform.right);
    }

    private void ForwardMovement()
    {
        transform.Translate(_currentSpeed * Time.deltaTime * transform.forward);
    }

    public void CanRun(bool b)
    {
        canRun = b;
    }


    #region POWER UPS
    public void SpeedPowerUpON(float amount)
    {
        _currentSpeed += amount;
    }
    public void SpeedPowerUpOFF()
    {
        ResetSpeed();
    }
    public void ResetSpeed()
    {
        _currentSpeed = forwardSpeed;
    }

    public void FlyON(float height, float duration, float animationDuration, Ease ease)
    {
        transform.DOMoveY(_startPos.y + height, animationDuration).SetEase(ease);
        DOVirtual.DelayedCall(duration, () => ResetHeight(animationDuration));
    }
    public void ResetHeight(float animationDuration)
    {
        transform.DOMoveY(_startPos.y, animationDuration / 2.0f).SetEase(Ease.InSine);
    }

    public void ChangeCoinCollectorRadius(float radius)
    {
        _coinCollector.radius = radius;
    }
    public void ResetCoinCollectorRadius()
    {
        _coinCollector.radius = _regularCoinCollectorRadius;
    }

    #endregion
}

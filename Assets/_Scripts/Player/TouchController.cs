using Leon.Core.InputActions;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    public bool canRun = false;
    public float forwardSpeed = 2.0f;
    public float sideSpeed = 0.1f;

    private PlayerInputActions _playerControls;
    private InputAction _tapOn;
    private InputAction _tapOff;
    private InputAction _screenPos;

    private Vector2 mousePos;

    #region Inputs / Awake
    private void Awake()
    {
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

    void Update()
    {
        if (!canRun) return;

        ForwardMovement();
        if (_tapOn.IsPressed())
        {
            SideMovement(_screenPos.ReadValue<Vector2>().x - mousePos.x);
        } 

        mousePos = _screenPos.ReadValue<Vector2>();
    }
    private void SideMovement(float speed)
    {
        transform.position += Vector3.right * Time.deltaTime * speed * sideSpeed;
    }

    private void ForwardMovement()
    {
        transform.Translate(transform.forward * forwardSpeed * Time.deltaTime);
    }

    public void Run(bool b)
    {
        canRun = b;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public FrameInput FrameInput { get; private set;}
    PlayerInputActions _playerInputActions;
    InputAction _move;
    InputAction _jump;
    InputAction _float;
    InputAction _menu;
    
    void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _move = _playerInputActions.Player.Move;
        _jump = _playerInputActions.Player.Jump;
        _float = _playerInputActions.Player.Float;
        _menu = _playerInputActions.Player.Menu;

    }
    
    void OnEnable()
    {
        _playerInputActions.Enable();
    }
    
    void OnDisable()
    {
        _playerInputActions.Disable();
    }

    void Update()
    {
        FrameInput = GatherInput();
    }

    FrameInput GatherInput()
    {
        return new FrameInput
        {
            Move = _move.ReadValue<Vector2>(),
            Jump = _jump.WasPressedThisFrame(),
            Float = _float.IsPressed(),
            Menu = _menu.WasPressedThisFrame()
        };
    }
}

public struct FrameInput
{
    public Vector2 Move;
    public bool Jump;
    public bool Float;
    public bool Menu;
}
using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
{
    public event Action JumpEvent;
    public event Action AttackEvent;
    public event Action LandingEvent;
    public event Action DashEvent;
    
    public Vector2 InputDirection { get; private set; }

    private Controls _controls;

    private void OnEnable()
    {
        if(_controls == null)
        {
            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
        }
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable(); //이거 유니티6부터 반드시 해줘야 한다.
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnLMouse(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnRMouse(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnQSkill(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnESkill(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}

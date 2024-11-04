using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerInputSO", menuName = "SO/PlayerInputSO")]
public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
{
    public event Action OnLMouseEvent;
    public event Action OnRMouseEvent;
    public event Action OnQSkillEvent;
    public event Action OnESkillEvent;
    
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
        _controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        InputDirection = context.ReadValue<Vector2>();
    }

    public void OnLMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnLMouseEvent?.Invoke();
    }

    public void OnRMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
            OnRMouseEvent?.Invoke();
    }

    public void OnQSkill(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnQSkillEvent?.Invoke();
    }

    public void OnESkill(InputAction.CallbackContext context)
    {
        if(context.performed)
            OnESkillEvent?.Invoke();
    }
}

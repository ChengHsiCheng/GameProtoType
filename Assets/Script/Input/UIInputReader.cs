using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputReader : MonoBehaviour, Controls.IMenuActions
{
    private Controls controls;

    public Vector2 Arrow { get; private set; }
    public Vector2 Stick { get; private set; }
    public Vector2 Point { get; private set; }
    public bool isClick { get; private set; }

    public event Action OnBackEvent;
    public event Action OnResetEvent;
    public event Action OnInteractiveEvent;
    public event Action OnArrowKeyEvent;
    public event Action OnCheckEvent;
    public event Action OnLeftTriggerEvent;
    public event Action OnRightTriggerEvent;
    public event Action OnLeftClickEvent;



    private void OnEnable()
    {
        controls = new Controls();
        controls.Menu.SetCallbacks(this);

        // 啟用輸入控制
        controls.Menu.Enable();


    }

    private void OnDisable()
    {
        // 禁用輸入控制
        controls.Menu.Disable();
    }

    private void SetControlMethod(InputAction.CallbackContext context)
    {
        if (context.control.device is Keyboard)
        {
            GameManager.SwitchControlMethod(ControlMethod.Keyboard);
        }

        if (context.control.device is Gamepad)
        {
            GameManager.SwitchControlMethod(ControlMethod.Gamepad);
        }

    }

    public void OnBack(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);
        OnBackEvent?.Invoke();
    }

    public void OnArrow(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Arrow = context.ReadValue<Vector2>();

        SetControlMethod(context);

        OnArrowKeyEvent?.Invoke();
    }

    public void OnInteractive(InputAction.CallbackContext context)
    {

        if (!context.performed)
            return;

        SetControlMethod(context);

        OnInteractiveEvent?.Invoke();
    }

    public void OnLeftStick(InputAction.CallbackContext context)
    {
        // if (!context.performed)
        //     return;

        SetControlMethod(context);

        Stick = context.ReadValue<Vector2>();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        OnCheckEvent?.Invoke();
    }

    public void OnLeftTrigger(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        OnLeftTriggerEvent?.Invoke();
    }

    public void OnRightTrigger(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        OnRightTriggerEvent?.Invoke();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        Point = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        isClick = context.performed;

        if (!context.performed)
            return;

        SetControlMethod(context);

        OnLeftClickEvent?.Invoke();
    }

    public void OnReset(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        OnResetEvent?.Invoke();
    }
}

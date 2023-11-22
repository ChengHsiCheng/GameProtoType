using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputReader : MonoBehaviour, Controls.IMenuActions
{
    private Controls controls;

    public Vector2 Arrow { get; private set; }
    public Vector2 Stick { get; private set; }
    public bool isInteractive { get; private set; }

    public event Action OnBackEvent;
    public event Action OnInteractiveEvent;
    public event Action OnArrowKeyEvent;
    public event Action OnCheckEvent;
    public event Action OnLeftTriggerEvent;
    public event Action OnRightTriggerEvent;



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

    public void OnBack(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnBackEvent?.Invoke();
    }

    public void OnArrow(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Arrow = context.ReadValue<Vector2>();

        OnArrowKeyEvent?.Invoke();
    }

    public void OnInteractive(InputAction.CallbackContext context)
    {
        isInteractive = context.performed;

        if (!context.performed)
            return;

        OnInteractiveEvent?.Invoke();
    }

    public void OnLeftStick(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        Stick = context.ReadValue<Vector2>();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnCheckEvent?.Invoke();
    }

    public void OnLeftTrigger(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnLeftTriggerEvent?.Invoke();
    }

    public void OnRightTrigger(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnRightTriggerEvent?.Invoke();
    }
}

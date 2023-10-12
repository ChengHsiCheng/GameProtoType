using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputReader : MonoBehaviour, Controls.IMenuActions
{
    private Controls controls;

    public Vector2 Arrow { get; private set; }

    public event Action OnBackEvent;
    public event Action OnArrowKeyEvent;


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
}

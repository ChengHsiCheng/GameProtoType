using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInputReader : MonoBehaviour, Controls.IMenuActions
{
    private Controls controls;

    public event Action OnBackEvent;

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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    private Controls controls;
    public Vector2 MovementValue { get; private set; } // 表示角色的移動輸入值

    public event Action RollEvent;

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        // 啟用輸入控制
        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        // 禁用輸入控制
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        RollEvent?.Invoke();
    }
}

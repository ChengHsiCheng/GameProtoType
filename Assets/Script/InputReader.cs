using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public bool IsAttacking { get; private set; }

    private Controls controls;
    public Vector2 MovementValue { get; private set; }

    public event Action RollEvent;
    public event Action SkillEvent;
    public event Action HealEvent;

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

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            IsAttacking = true;
        }
        else if (context.canceled)
        {
            IsAttacking = false;
        }
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SkillEvent?.Invoke();
    }

    public void OnHeal(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        HealEvent?.Invoke();
    }
}

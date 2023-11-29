using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.ICombatLevelActions
{
    public bool IsAttacking { get; private set; }

    private Controls controls;
    public Vector2 MovementValue { get; private set; }

    public event Action RollEvent;
    public event Action SkillEvent;
    public event Action HealEvent;
    public event Action TogglePauseEvent;
    public event Action SanCheckEvent;
    public event Action InteractionEvent;

    private void OnEnable()
    {
        controls = new Controls();
        controls.CombatLevel.SetCallbacks(this);

        // 啟用輸入控制
        controls.CombatLevel.Enable();
    }

    private void OnDisable()
    {
        // 禁用輸入控制
        controls.CombatLevel.Disable();
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

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();

        SetControlMethod(context);
    }

    public void OnRoll(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

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

        SetControlMethod(context);
    }

    public void OnSkill(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        SkillEvent?.Invoke();
    }

    public void OnHeal(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        HealEvent?.Invoke();
    }

    public void OnESC(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        TogglePauseEvent?.Invoke();
    }

    public void OnSanCheck(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        SanCheckEvent?.Invoke();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SetControlMethod(context);

        InteractionEvent?.Invoke();
    }
}

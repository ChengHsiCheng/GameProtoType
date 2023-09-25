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

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();

        if (context.control.device is Keyboard)
        {
            GameManager.controlMethod = ControlMethod.Keyboard;
        }

        if (context.control.device is Gamepad)
        {
            GameManager.controlMethod = ControlMethod.Gamepad;
        }
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

    public void OnESC(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        TogglePauseEvent?.Invoke();
    }

    public void OnSanCheck(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SanCheckEvent?.Invoke();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        InteractionEvent?.Invoke();
    }
}

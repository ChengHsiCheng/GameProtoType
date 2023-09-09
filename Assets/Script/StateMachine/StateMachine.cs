using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected State currentState { get; private set; } // 目前的State
    public bool canMove { get; protected set; } = true;

    protected float freezeTime;

    /// <summary>
    /// 切換State
    /// </summary>
    /// <param name="newState">要切換的State</param>
    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();

        //  Debug.Log(newState);
    }

    void Update()
    {
        if (GameManager.isPauseGame)
            return;

        if (Time.time >= freezeTime && !canMove)
        {
            SetCanMove(true);
            return;
        }

        if (canMove)
        {
            currentState?.Tick(Time.deltaTime);
            return;
        }
    }

    public abstract void SetCanMove(bool value);

    public abstract void SetCanMove(bool value, float time);

    public abstract void OnGameTogglePause(bool isPause);

}

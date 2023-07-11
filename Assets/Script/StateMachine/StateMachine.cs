using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State currentState; // 目前的State
    [SerializeField] protected bool canMove = true;

    /// <summary>
    /// 切換State
    /// </summary>
    /// <param name="newState">要切換的State</param>
    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();

        Debug.Log(newState);
    }

    void Update()
    {
        if (!canMove)
            return;
        currentState?.Tick(Time.deltaTime);
    }

    public abstract void SetCanMove(bool value);

}

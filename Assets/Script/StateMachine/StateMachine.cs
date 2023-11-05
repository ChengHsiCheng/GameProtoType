using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State currentState { get; private set; } // 目前的State

    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public SkinnedMeshRenderer Material { get; private set; }

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

        Debug.Log(gameObject.name + "State: " + newState);
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

    public virtual void SetCanMove(bool value)
    {
        SetCanMove(value, 0);

        Material?.material.SetFloat("_Petrifaction", 1);
    }

    public virtual void SetCanMove(bool value, float time)
    {
        canMove = value;
        freezeTime = Time.time + time;

        int intValue = canMove ? 1 : 0; // 把canMove轉成1或0

        Animator.SetFloat("AnimationSpeed", intValue);
    }

    public virtual void OnGameTogglePause(bool isPause)
    {
        if (!isPause && freezeTime != 0)
        {
            return;
        }

        int intValue = isPause ? 0 : 1; // 把canMove轉成1或0
        Animator?.SetFloat("AnimationSpeed", intValue);
    }

}

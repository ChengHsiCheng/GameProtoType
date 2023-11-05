using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boss03BaseState : State
{
    protected Boss03StateMachine stateMachine;

    public Boss03BaseState(Boss03StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// 面對目標
    /// </summary>
    protected void EyeFaceTarget(Vector3 targetPos, float rotationSpeed)
    {
        targetPos.y = 1;
        Vector3 direction = targetPos - stateMachine.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    protected void Whirling(Vector3 euluers, float deltaTime)
    {
        stateMachine.BigRing.transform.Rotate(euluers * stateMachine.ringSpeed * deltaTime);
        stateMachine.SmallRing.transform.Rotate(-euluers * stateMachine.ringSpeed * deltaTime);
    }
}

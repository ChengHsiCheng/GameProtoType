using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TentacleBaseState : State
{
    protected TentacleStateMachine stateMachine;

    public TentacleBaseState(TentacleStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// 面對目標
    /// </summary>
    protected void FaceTarget(Vector3 targetPos, float rotationSpeed)
    {
        Vector3 direction = stateMachine.transform.position - targetPos;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}



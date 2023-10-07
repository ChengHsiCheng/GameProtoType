using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Boss02BaseState : State
{
    protected enum SkillCount
    {
        CursedVestmentSkill
    }

    protected Boss02StateMachine stateMachine;

    public Boss02BaseState(Boss02StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    /// <summary>
    /// 面對目標
    /// </summary>
    protected void FaceTarget(Vector3 targetPos, float rotationSpeed)
    {
        targetPos.y = stateMachine.transform.position.y;
        Vector3 direction = targetPos - stateMachine.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}

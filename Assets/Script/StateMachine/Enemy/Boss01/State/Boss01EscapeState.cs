using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss01EscapeState : Boss01BaseState
{
    private readonly int MoveSpeedString = Animator.StringToHash("MoveSpeed");
    private readonly int MovingBlendTreeHash = Animator.StringToHash("MovingBlendTree");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    private GameObject[] escapePoint;
    private Vector3 targetPos;

    public Boss01EscapeState(Boss01StateMachine stateMachine, GameObject[] escapePoint) : base(stateMachine)
    {
        this.escapePoint = escapePoint;
    }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(MovingBlendTreeHash, CrossFadeDuration);

        targetPos = GetFarthestEscapePoint();
        targetPos.y = 0;
    }

    public override void Tick(float deltaTime)
    {
        if (GetTargetAngle(targetPos) >= 5)
        {
            FaceTarget();
            return;
        }

        if (Vector3.Distance(stateMachine.transform.position, targetPos) <= 1)
        {
            BackTransitionState();
            return;
        }

        MoveToTarget(targetPos, deltaTime);

        stateMachine.Animator.SetFloat(MoveSpeedString, 1, AnimatorDampTime, deltaTime);
    }

    public override void Exit()
    {
        if (stateMachine.Agent.isOnNavMesh)
        {
            // 重置導航路徑
            stateMachine.Agent.ResetPath();
        }

        // 停止導航代理的運動
        stateMachine.Agent.velocity = Vector3.zero;
    }

    private Vector3 GetFarthestEscapePoint()
    {
        float maxDistance = 0f;
        GameObject farthestObject = null;

        foreach (GameObject obj in escapePoint)
        {
            float distance = Vector3.Distance(stateMachine.transform.position, obj.transform.position);

            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestObject = obj;
            }
        }

        return farthestObject.transform.position;
    }

    protected void FaceTarget()
    {
        if (targetPos == null)
            return;

        Vector3 direction = targetPos - stateMachine.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        stateMachine.transform.rotation = Quaternion.RotateTowards(stateMachine.transform.rotation, targetRotation, stateMachine.rotationSpeed * Time.deltaTime);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02IdleState : Boss02BaseState
{
    // private Vector3 targetPos;

    public Boss02IdleState(Boss02StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        // targetPos = RandomPointInRingArea(stateMachine.MinMoveRadius, stateMachine.MaxMoveRadius);
    }

    public override void Tick(float deltaTime)
    {

        // FaceTarget(GameManager.player.transform.position, stateMachine.RototeSpeed);

        // // 計算前往目標座標的方向
        // Vector3 moveDirection = (targetPos - stateMachine.transform.position).normalized;

        // // 使用CharacterController移動
        // stateMachine.Controller.Move(moveDirection * stateMachine.MoveSpeed * Time.deltaTime);

        // // 檢查是否到達目標座標
        // if (Vector3.Distance(stateMachine.transform.position, targetPos) <= 0.3f)
        // {
        //     targetPos = RandomPointInRingArea(stateMachine.MinMoveRadius, stateMachine.MaxMoveRadius);
        // }
    }

    public override void Exit()
    {
    }

    // Vector3 RandomPointInRingArea(float innerRadius, float outerRadius)
    // {
    //     // 生成一個隨機的角度
    //     float randomAngle = Random.Range(0f, 360f);

    //     // 將角度轉換為弧度
    //     float radians = randomAngle * Mathf.Deg2Rad;

    //     // 生成一個隨機的距離在內半徑和外半徑之間
    //     float randomDistance = Random.Range(innerRadius, outerRadius);

    //     // 計算隨機點的座標
    //     float x = Mathf.Cos(radians) * randomDistance;
    //     float y = Mathf.Sin(radians) * randomDistance;

    //     Debug.Log(new Vector3(x, 3, y));

    //     return new Vector3(x, 3, y);
    // }

}

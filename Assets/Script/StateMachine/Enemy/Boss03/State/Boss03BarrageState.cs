using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03BarrageState : Boss03BaseState
{
    private EnemySkill[] skill;

    private float wave;
    private float waveCount;
    private float interval = 1;
    private float timer;

    private Vector3 targetPos = new Vector3(0, 0, 22);

    public Boss03BarrageState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        skill = stateMachine.BarrageSkills;
        wave = Random.Range(5, 11);
    }

    public override void Tick(float deltaTime)
    {
        EyeFaceTarget(GameManager.player.transform.position, stateMachine.rotationSpeed);

        Whirling(-Vector3.one, 1.5f, deltaTime);

        if (Vector3.Distance(stateMachine.transform.position, targetPos) > 0.5f)
        {
            stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, targetPos, 15 * deltaTime);
            return;
        }

        timer += deltaTime;

        if (timer >= interval)
        {
            int r = Random.Range(0, skill.Length);
            skill[r].skill.castTransform = stateMachine.Eye.transform;
            skill[r].skill.UseSkill();
            timer = 0;
            waveCount++;
        }

        if (waveCount >= wave)
        {
            stateMachine.SwitchState(new Boss03IdleState(stateMachine));
            return;
        }

    }

    public override void Exit()
    {
        stateMachine.SetCoolDown(Random.Range(skill[0].MinCooldownTime, skill[0].MaxCooldownTime));
    }

}

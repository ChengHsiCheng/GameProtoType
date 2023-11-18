using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03BarrageState : Boss03BaseState
{
    private EnemySkill[] skill;
    private EnemySkill laserSkill;

    private float wave;
    private float waveCount;
    private float interval = 1;
    private float timer;

    private int[] ints = { 0, 0, 0, 0 };

    private bool isBarraheMode;

    private Vector3 targetPos = new Vector3(0, 0, 22);

    public Boss03BarrageState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        skill = stateMachine.BarrageSkills;
        laserSkill = stateMachine.LaserSkill;

        isBarraheMode = Random.Range(0, 2) == 0;

        if (isBarraheMode)
        {
            wave = Random.Range(10, 15);
        }
        else
        {
            wave = Random.Range(2, 5);
        }
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

        if (!stateMachine.isBarrageState)
        {
            stateMachine.SwitchState(new Boss03IdleState(stateMachine));
            return;
        }

        if (timer >= interval)
        {
            if (isBarraheMode)
            {
                int r = Random.Range(0, skill.Length);
                Skill _skill = GameObject.Instantiate(skill[r].skill);
                _skill.castTransform = stateMachine.Eye.transform;
                _skill.UseSkill();
                interval = Random.Range(skill[r].MinCooldownTime, skill[r].MaxCooldownTime);
            }
            else
            {
                laserSkill.skill.UseSkill();
                interval = Random.Range(laserSkill.MinCooldownTime, laserSkill.MaxCooldownTime);
            }

            timer = 0;
            waveCount++;
        }

        if (waveCount >= wave)
        {
            waveCount = 0;
            isBarraheMode = !isBarraheMode;

            if (isBarraheMode)
            {
                wave = Random.Range(10, 15);
            }
            else
            {
                wave = Random.Range(2, 5);
            }
        }

    }

    public override void Exit()
    {
        stateMachine.SetCoolDown(Random.Range(skill[0].MinCooldownTime, skill[0].MaxCooldownTime));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03BarrageState : Boss03BaseState
{
    private EnemySkill[] skill;
    private EnemySkill laserSkill;

    private int wave;
    private int waveCount;
    private float interval;
    private float timer;

    private bool isBarraheMode = true;

    private Vector3 targetPos = new Vector3(0, 0, 22);

    public Boss03BarrageState(Boss03StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        skill = stateMachine.BarrageSkills;
        laserSkill = stateMachine.LaserSkill;

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
                EnemySkill _skill;

                _skill = skill[waveCount % 2];

                _skill.skill.castTransform = stateMachine.Eye.transform;
                _skill.skill.UseSkill();
                interval = _skill.MinCooldownTime;

                if (waveCount % 3 == 0 && waveCount != 0)
                {
                    _skill = skill[2];

                    _skill.skill.castTransform = stateMachine.Eye.transform;
                    _skill.skill.UseSkill();
                }

                stateMachine.AudioLogic.PlayAudio("BarrageShoot");
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
                wave = Random.Range(12, 19);
            }
            else
            {
                wave = Random.Range(2, 5);
            }
        }

    }

    public override void Exit()
    {
        // stateMachine.SetCoolDown(Random.Range(skill[0].MinCooldownTime, skill[0].MaxCooldownTime));
    }

}

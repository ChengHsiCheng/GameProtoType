using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrifySkill : Skill
{
    public override void UseSkill()
    {
        foreach (StateMachine enemy in GameManager.enemys)
        {
            enemy.SetCanMove(false, 1);
        }
    }
}

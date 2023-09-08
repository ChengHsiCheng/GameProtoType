using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrifySkill : Skill
{
    public override void UseSkill()
    {
        foreach (Enemy enemy in GameManager.enemys)
        {
            enemy.BePetrify();

            Debug.Log(enemy);
        }
    }
}

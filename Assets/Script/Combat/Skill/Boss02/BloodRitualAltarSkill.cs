using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRitualAltarSkill : Skill
{
    [SerializeField] private Boss02BelieverStateMachine[] believers;
    private float SacrificeTime;

    public override void UseSkill()
    {
        believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();

        SacrificeTime = 0;

        foreach (Boss02BelieverStateMachine believer in believers)
        {
            SacrificeTime += 3;

            believer.SwitchState(new Boss02BelieverSacrificeState(believer, SacrificeTime));
            Debug.Log("BloodRitualAltarSkill" + SacrificeTime);
        }
    }
}

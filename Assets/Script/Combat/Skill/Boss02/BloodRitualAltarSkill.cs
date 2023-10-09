using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodRitualAltarSkill : Skill
{
    [SerializeField] private Boss02BelieverStateMachine[] believers;
    private float SacrificeTime = 3;

    public override void UseSkill()
    {
        believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();

        foreach (Boss02BelieverStateMachine believer in believers)
        {
            believer.SwitchState(new Boss02BelieverSacrificeState(believer, SacrificeTime));
            SacrificeTime += 3;
        }
    }
}

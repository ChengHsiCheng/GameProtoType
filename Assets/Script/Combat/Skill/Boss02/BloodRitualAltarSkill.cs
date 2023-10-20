using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BloodRitualAltarSkill : Skill
{
    [SerializeField] private Boss02BelieverStateMachine[] believers;
    private float SacrificeTime;
    private float timer;

    public override void UseSkill()
    {
        believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();

        SacrificeTime = 0;

        foreach (Boss02BelieverStateMachine believer in believers)
        {
            SacrificeTime += 3;

            believer.SwitchState(new Boss02BelieverSacrificeState(believer, SacrificeTime));

            believer.OnSacrificeEvent += OnSacrifice;
            believer.OnDieEvent += OnCancelEvent;

            Debug.Log("BloodRitualAltarSkill" + SacrificeTime);
        }
    }

    private void OnSacrifice(Boss02BelieverStateMachine Believer)
    {
        GameManager.player.GetComponent<Health>().DealHealthDamage(10, false);

        OnCancelEvent(Believer);
    }

    private void OnCancelEvent(Boss02BelieverStateMachine Believer)
    {
        Believer.OnSacrificeEvent -= OnSacrifice;
        Believer.OnDieEvent -= OnCancelEvent;
    }
}

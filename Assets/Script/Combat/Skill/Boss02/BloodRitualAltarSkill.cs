using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BloodRitualAltarSkill : Skill
{
    private Boss02BelieverStateMachine[] believers;
    private float sacrificeTime;
    private int sacrificeCount;

    private AltarHealth altar;
    private Boss02StateMachine boss02;

    public override void UseSkill()
    {
        believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();
        boss02 = GameObject.FindObjectOfType<Boss02StateMachine>();
        altar = GameObject.FindObjectOfType<AltarHealth>();

        sacrificeTime = 0;
        sacrificeCount = 0;

        foreach (Boss02BelieverStateMachine believer in believers)
        {
            if (believer.isDied)
                return;

            sacrificeTime += 1;
            believer.SwitchState(new Boss02BelieverSacrificeState(believer, sacrificeTime));

            believer.OnSacrificeEvent += OnSacrifice;
            believer.OnDieEvent += OnCancelEvent;
        }

        if (believers.Length == 0)
            return;

        altar.SwitchBloodRitualAltarSkill(true);

        Invoke("CalculateDamage", believers.Length + 2);
    }

    private void CalculateDamage()
    {
        if (believers.Length <= 0)
            return;

        GameManager.player.GetComponent<Health>().DealHealthDamage(sacrificeCount * 10, false);

        altar.Healing(sacrificeCount * 10);
        altar.SwitchBloodRitualAltarSkill(false);
    }

    private void OnSacrifice(Boss02BelieverStateMachine Believer)
    {
        sacrificeCount += 1;
        OnCancelEvent(Believer);
    }

    private void OnCancelEvent(Boss02BelieverStateMachine Believer)
    {
        Believer.OnSacrificeEvent -= OnSacrifice;
        Believer.OnDieEvent -= OnCancelEvent;
    }
}

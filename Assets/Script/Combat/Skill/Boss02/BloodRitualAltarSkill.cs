using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BloodRitualAltarSkill : Skill
{
    [SerializeField] private Boss02BelieverStateMachine[] believers;
    private float sacrificeTime;
    private int sacrificeCount;

    public override void UseSkill()
    {
        believers = GameObject.FindObjectsOfType<Boss02BelieverStateMachine>();

        sacrificeTime = 0;
        sacrificeCount = 0;

        foreach (Boss02BelieverStateMachine believer in believers)
        {
            if (believer.isDied)
                return;

            sacrificeTime += 3;
            believer.SwitchState(new Boss02BelieverSacrificeState(believer, sacrificeTime));

            believer.OnSacrificeEvent += OnSacrifice;
            believer.OnDieEvent += OnCancelEvent;

            Debug.Log("BloodRitualAltarSkill" + sacrificeTime);
        }

        Invoke("CalculateDamage", (believers.Length + 1) * 3);
    }

    private void CalculateDamage()
    {
        // 特效

        if (believers.Length <= 0)
            return;

        GameManager.player.GetComponent<Health>().DealHealthDamage(sacrificeCount * 10, false);
        Debug.Log("CalculateDamage");
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

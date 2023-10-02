using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss02StateMachine : StateMachine, Enemy
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public Boss02Info Health { get; private set; }
    [field: SerializeField] public SkinnedMeshRenderer Material { get; private set; }
    [field: SerializeField] public Skill[] Skill { get; private set; }

    protected PlayerStateMachine player;

    [field: SerializeField] public GameObject Altarobj { get; private set; }
    public Health AltarHealth { get; private set; }

    [field: SerializeField] public Crown crown { get; private set; }

    private void Start()
    {
        GameManager.enemys.Add(this);
        player = GameManager.player.GetComponent<PlayerStateMachine>();

        AltarHealth = Instantiate(Altarobj, Vector3.zero, Quaternion.identity).GetComponent<Health>();

        SwitchState(new Boss02StartState(this));

        AltarHealth.OnTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        AltarHealth.OnTakeDamage -= TakeDamage;

        GameManager.enemys.Remove(this);
    }

    private void TakeDamage()
    {
        if (!player.haveCrown)
            return;

        Debug.Log("2");
    }

    public override void OnGameTogglePause(bool isPause)
    {
        if (!isPause && freezeTime != 0)
        {
            return;
        }


        int intValue = isPause ? 0 : 1; // 把canMove轉成1或0
        Animator.SetFloat("AnimationSpeed", intValue);
    }

    public override void SetCanMove(bool value)
    {
        SetCanMove(value, 0);

        Material.material.SetFloat("_Petrifaction", 1);
    }

    public override void SetCanMove(bool value, float time)
    {
        this.canMove = canMove;
        this.freezeTime = Time.time + freezeTime;

        int intValue = canMove ? 1 : 0; // 把canMove轉成1或0

        Animator.SetFloat("AnimationSpeed", intValue);
    }

    public void BePetrify()
    {
        SetCanMove(false, 3f);

        Material.material.SetFloat("_Petrifaction", 0);
    }
}

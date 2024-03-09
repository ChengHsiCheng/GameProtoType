using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss02StateMachine : StateMachine, Enemy
{
    [field: SerializeField] public EnemySkill[] Skill { get; private set; }
    [field: SerializeField] public TentacleStateMachine[] Tentacles { get; private set; }
    [field: SerializeField] public EnemyInfo info { get; private set; }
    [field: SerializeField] public BarController bar { get; private set; }
    [field: SerializeField] public GameObject CameraTarget { get; private set; }
    [field: SerializeField] public float CooldDown { get; private set; }

    public bool canCallBelievers { get; private set; } = true;

    [SerializeField] private Boss02Altar AltarPrefab;
    public Boss02Altar Altar { get; private set; }

    protected PlayerStateMachine player;

    private void Start()
    {
        GameManager.enemys.Add(this);
        player = GameManager.player.GetComponent<PlayerStateMachine>();

        SwitchState(new Boss02StartState(this));

        Altar = Instantiate(AltarPrefab, new Vector3(-9, 0, 9), Quaternion.identity);

        Altar.OnTakeDamageEvent += DealHealthDamage;
        Altar.OnShieldBrokenEvent += OnShieldBroken;

        info.OnTakeDamage += DealHealthDamage;

        info.OnDie += OnDie;

        Tentacles = GameObject.FindObjectsOfType<TentacleStateMachine>();
    }


    private void OnDisable()
    {
        GameManager.enemys.Remove(this);

        Altar.OnTakeDamageEvent -= DealHealthDamage;
        Altar.OnShieldBrokenEvent -= OnShieldBroken;

        info.OnDie -= OnDie;

    }

    private void OnShieldBroken()
    {
        SwitchState(new Boss02FaintState(this));
    }

    public void DealHealthDamage(float damage)
    {
        info.DealHealthDamage(damage, false);
    }

    public void DealHealthDamage()
    {
        bar.SetBar(info.health / info.maxHealth);
    }

    private void OnDie()
    {
        SwitchState(new Boss02DieState(this));
    }

    public void SetCooldDown(float value)
    {
        CooldDown = value;
    }

    public void SetCanCallBelievers(bool value)
    {
        canCallBelievers = value;
    }

    public void BePetrify()
    {
        SetCanMove(false, 3f);

        Material.material.SetFloat("_Petrifaction", 0);
    }
}

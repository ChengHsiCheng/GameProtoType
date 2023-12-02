using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss02StateMachine : StateMachine, Enemy
{
    [field: SerializeField] public EnemySkill[] Skill { get; private set; }
    [field: SerializeField] public GameObject CameraTarget { get; private set; }
    [field: SerializeField] public float CooldDown { get; private set; }

    [SerializeField] private Boss02Altar Altarobj;
    private Boss02Altar Altar;

    protected PlayerStateMachine player;

    private void Start()
    {
        GameManager.enemys.Add(this);
        player = GameManager.player.GetComponent<PlayerStateMachine>();

        SwitchState(new Boss02StartState(this));

        Altar = Instantiate(Altarobj, new Vector3(-9, 0, 9), Quaternion.identity);
    }

    private void OnDisable()
    {
        GameManager.enemys.Remove(this);
    }

    public void SetCooldDown(float value)
    {
        CooldDown = value;
    }

    public void BePetrify()
    {
        SetCanMove(false, 3f);

        Material.material.SetFloat("_Petrifaction", 0);
    }
}

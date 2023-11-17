using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss03StateMachine : StateMachine, Enemy
{
    [field: SerializeField] public GameObject Eye { get; private set; }
    [field: SerializeField] public GameObject BigRing { get; private set; }
    [field: SerializeField] public GameObject SmallRing { get; private set; }
    [field: SerializeField] public VFXPlayer VFXPlayer { get; private set; }
    [field: SerializeField] public EnemySkill[] BarrageSkills { get; private set; }
    [field: SerializeField] public EnemySkill LaserSkill { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }
    [field: SerializeField] public Boss03Crystal Crystal { get; private set; }
    [field: SerializeField] public List<Boss03Crystal> Crystals { get; private set; } = new List<Boss03Crystal>() { };
    [field: SerializeField] public Boss03SceneController sceneController { get; private set; }


    [field: SerializeField] public bool isBarrageState { get; private set; }
    [field: SerializeField] public bool isFallAttack { get; private set; }
    [field: SerializeField] public float crystalsAmount { get; private set; }
    [field: SerializeField] public float meleeStateMaxTime { get; private set; }
    [field: SerializeField] public float meleeStateTimer { get; private set; }
    [field: SerializeField] public float coolDown { get; private set; }
    [field: SerializeField] public float baseRingSpeed { get; private set; }
    [field: SerializeField] public float rotationSpeed { get; private set; }

    private void Start()
    {
        GameManager.enemys.Add(this);
        sceneController = GameManager.sceneController.GetComponent<Boss03SceneController>();
        SwitchState(new Boss03IdleState(this));
    }

    private void OnDisable()
    {
        GameManager.enemys.Remove(this);
    }

    private void CrystalDestroyEvent(Boss03Crystal crystal)
    {
        Crystals.Remove(crystal);
        crystal.OnDestroyEvent -= CrystalDestroyEvent;

        if (Crystals.Count == 0)
        {
            SetIsBarrageState(false);
        }
    }

    public void SetIsBarrageState(bool isBarrageState)
    {
        this.isBarrageState = isBarrageState;
        SwitchState(new Boss03SwitchModeState(this));
    }

    public void SwitchBossMdoe()
    {
        if (isBarrageState)
            SwitchBarrageState();
        else
            SwitchMeleeState();
    }

    public void SwitchBarrageState()
    {
        for (int i = 0; i < crystalsAmount; i++)
        {
            Boss03Crystal crystal = Instantiate(Crystal, new Vector3(Random.Range(-15.0f, 15.0f), 1, Random.Range(-15.0f, 10.0f)), Crystal.transform.rotation);
            Crystals.Add(crystal);
            crystal.OnDestroyEvent += CrystalDestroyEvent;
        }
    }

    public void SwitchMeleeState()
    {
        // 切換近戰
        meleeStateTimer = 0;
    }

    public void SetFallAttack(bool fallAttack)
    {
        isFallAttack = fallAttack;
    }

    public void SetMeleeStateTimer(float timer)
    {
        meleeStateTimer = timer;
    }

    public void SetCoolDown(float coolDown)
    {
        this.coolDown = coolDown;
    }

    public override void OnGameTogglePause(bool isPause)
    {
    }

    public void BePetrify()
    {
    }
}

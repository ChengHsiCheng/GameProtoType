using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float moveSmooth { get; private set; } // 移動加速度起始值
    [field: SerializeField] public float rollSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }
    [field: SerializeField] public float RollTime { get; private set; } // 躲避時間
    [field: SerializeField] public float RollLength { get; private set; } // 躲避距離
    public Transform MainCameraTransform { get; private set; }

    private void Awake()
    {
        GameManager.player = this.gameObject;
    }

    private void Start()
    {
        SwitchState(new PlayerMovingState(this));

        MainCameraTransform = Camera.main.transform;
    }

    public override void SetCanMove(bool value)
    {
    }
    public override void SetCanMove(bool value, float time)
    {
    }
}

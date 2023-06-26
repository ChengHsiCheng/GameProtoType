using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public WeaponDamage Weapon { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    [field: SerializeField] public float moveSpeed { get; private set; }
    [field: SerializeField] public float rollSpeed { get; private set; }
    [field: SerializeField] public float RotationDamping { get; private set; }
    [field: SerializeField] public float RollTime { get; private set; } // 躲避時間
    [field: SerializeField] public float RollLength { get; private set; } // 躲避距離
    public Transform MainCameraTransform { get; private set; }

    private void Start()
    {
        SwitchState(new PlayerMovingState(this));

        MainCameraTransform = Camera.main.transform;
    }


}

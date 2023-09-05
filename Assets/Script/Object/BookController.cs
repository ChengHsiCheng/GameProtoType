using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    [SerializeField] private Animator Animator;


    public void PlayerAnimation()
    {
        Animator.SetTrigger("UseSkill");
    }
}

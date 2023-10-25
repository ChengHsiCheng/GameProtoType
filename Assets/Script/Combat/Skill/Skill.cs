using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public Transform castTransform;

    public virtual void SkillUpdate() { }

    public virtual void UseSkill() { }

    public virtual void DestroySkill() { }
}

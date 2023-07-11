using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXHendler : MonoBehaviour
{
    public VFXControls vfx;

    protected void SkillCaster()
    {
        Instantiate(vfx);
    }
}

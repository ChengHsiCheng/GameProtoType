using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireStormSkill : Skill
{
    [SerializeField] private TrackProjectileControls fireStorm;

    void Start()
    {
        TrackProjectileControls iFireStorm = Instantiate(fireStorm, transform.position, transform.rotation);
        iFireStorm.SetValue(3, 10, GameManager.player);

        Destroy(gameObject);
    }

}

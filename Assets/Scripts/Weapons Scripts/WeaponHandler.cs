using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tags;

public class WeaponHandler : MonoBehaviour
{

    private Animator anim;

    public WeaponFireType fireType;

    public GameObject attack_Point;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }
}

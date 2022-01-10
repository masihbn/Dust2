using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tags;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weaponManager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }

    private void WeaponShoot()
    {
        // if we have assault riffle
        if (weaponManager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            // if we press and hold left mouse click AND
            // if Time is greater than the nextTimeToFire
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
            }
        }

        else
        {

            if (Input.GetMouseButtonDown(0))
                weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
        }
    }
}

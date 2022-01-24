using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tags;


public class PlayerAttack : MonoBehaviour
{

    private WeaponManager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Camera mainCam;

    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();

        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        WeaponShoot();
    }

    void WeaponShoot()
    {
        // if we have assault riffle
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE)
        {
            // if we press and hold left mouse click AND
            // if Time is greater than the nextTimeToFire
            if (Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                StartCoroutine(ExampleCoroutine());

                BulletFired();
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                    StartCoroutine(ExampleCoroutine());

                    BulletFired();
                }

            } // if input get mouse button 0

        } // else

    } // weapon shoot

    void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.tag == CharacterTag.ENEMY_TAG)
            {
                Debug.Log("hit enemy");
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
    } // bullet fired

    IEnumerator ExampleCoroutine()
    {
        weapon_Manager.GetCurrentSelectedWeapon().Turn_On_MuzzleFlash();

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.01f);

        //After we have waited 5 seconds print the time again.
        weapon_Manager.GetCurrentSelectedWeapon().Turn_Off_MuzzleFlash();
    }

} // class

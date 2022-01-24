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
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE &&
            Input.GetMouseButton(0) && Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                //weapon_Manager.GetCurrentSelectedWeapon().Play_ShootSound();
                StartCoroutine(ExampleCoroutine());

                BulletFired();
            }

        else
        {
            if (Input.GetMouseButtonDown(0) &&
                weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
            {
                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                //weapon_Manager.GetCurrentSelectedWeapon().Play_ShootSound();
                StartCoroutine(ExampleCoroutine());

                BulletFired();
            } 

        } 

    } 

    void BulletFired()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            if (hit.transform.tag == CharacterTag.ENEMY_TAG)
            {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            }
        }
    } 

    IEnumerator ExampleCoroutine()
    {
        weapon_Manager.GetCurrentSelectedWeapon().Turn_On_MuzzleFlash();

        yield return new WaitForSeconds(0.01f);

        weapon_Manager.GetCurrentSelectedWeapon().Turn_Off_MuzzleFlash();
    }

} 

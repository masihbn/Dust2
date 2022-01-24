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

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    private bool is_Aiming;

    [SerializeField]
    private GameObject arrow_Prefab, spear_Prefab;

    [SerializeField]
    private Transform arrow_Bow_StartPosition;

    void Awake()
    {

        weapon_Manager = GetComponent<WeaponManager>();

        mainCam = Camera.main;
    }

    // Use this for initialization
    void Start()
    {

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


            // if we have a regular weapon that shoots once
        }
        else
        {

            if (Input.GetMouseButtonDown(0))
            {
                // handle shoot
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
        Debug.Log("Bullet fired");
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit))
        {
            Debug.Log("Don't know what's going on" + hit.transform.name);

            if (hit.transform.tag == Tags.CharacterTag.ENEMY_TAG)
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

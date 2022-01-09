using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    [SerializeField]
    private WeaponHandler[] weapons;

    private int current_Weapon_Index;

    // Use this for initialization
    void Start()
    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if (current_Weapon_Index == weaponIndex)
            return;

        weapons[current_Weapon_Index].gameObject.SetActive(false);
        weapons[weaponIndex].gameObject.SetActive(true);
        current_Weapon_Index = weaponIndex;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    [SerializeField]
    private Slider health_Stats, stamina_Stats;

    public void Display_HealthStats(float healthValue) {

        healthValue /= 100f;
        if(health_Stats.maxValue <= 100f) {
            health_Stats.value = healthValue;
            Debug.LogWarning("Health damage "+healthValue);
        }
            else Debug.LogWarning("Health States not found");

    }

    public void Display_StaminaStats(float staminaValue) {

        staminaValue /= 100f;
        if(stamina_Stats.maxValue <= 100f) {
            stamina_Stats.value = staminaValue;
            Debug.LogWarning("Stamina loss "+staminaValue);
        }
            else Debug.LogWarning("stamina States not found");

    }


} // class






























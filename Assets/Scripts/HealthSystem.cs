using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    public static Action<int> ModifyHealth;
    public static Action<int> UpdateHealth;

     int health = 10;

    private void OnEnable()
    {
        ModifyHealth += UpdateCurrentHealth;
    }
    private void OnDisable()
    {
        ModifyHealth -= UpdateCurrentHealth;
    }

    public void UpdateCurrentHealth(int number)
    {
        health += number;
        UpdateHealth?.Invoke(health);
        if(health <= 0)
        {
            GameManager.onLoose?.Invoke();
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] HandlerEvents ModifyHealth;
    [SerializeField] HandlerEvents UpdateHealth;

    public IvHandlerEvent IvHandlerLoose;
   
     int health = 10;

    private void OnEnable()
    {
        ModifyHealth.eventScriptableObject += UpdateCurrentHealth;
    }
    private void OnDisable()
    {
        ModifyHealth.eventScriptableObject -= UpdateCurrentHealth;
    }

    public void UpdateCurrentHealth(int number)
    {
        health += number;
        UpdateHealth.InvokeAction(health);
        if(health <= 0)
        {
           
            IvHandlerLoose.ActivateGameCondition();
        }

    }


}

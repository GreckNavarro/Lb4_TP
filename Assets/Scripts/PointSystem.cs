using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PointSystem : MonoBehaviour
{
    [SerializeField] HandlerEvents GainPoints;
    [SerializeField] HandlerEvents UpdatePoints;

    
    int Points = 0;

    private void OnEnable()
    {
        GainPoints.eventScriptableObject += UpdateCurrentsPoints;
    }
    private void OnDisable()
    {
        GainPoints.eventScriptableObject -= UpdateCurrentsPoints;
    }
    private void UpdateCurrentsPoints(int number)
    {
        Points += number;
        UpdatePoints.InvokeAction(Points);
        if (Points >= 90)
        {
            GameManager.onWin?.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PointSystem : MonoBehaviour
{
    public static Action<int> GainPoints;
    public static Action<int> UpdatePoints;
    int Points = 0;

    private void OnEnable()
    {
        GainPoints += UpdateCurrentsPoints;
    }
    private void OnDisable()
    {
        GainPoints -= UpdateCurrentsPoints;
    }
    private void UpdateCurrentsPoints(int number)
    {
        Points += number;
        UpdatePoints?.Invoke(Points);
        if (Points >= 90)
        {
            GameManager.onWin?.Invoke();
        }
    }
}

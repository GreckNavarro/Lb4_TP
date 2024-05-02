using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Game Condition", menuName = "ScriptableObject/HandlerEventPoints", order = 1)]
public class IvHandlerEvent : ScriptableObject
{
    public event Action OnGameCondition;

    public void ActivateGameCondition()
    {
        OnGameCondition?.Invoke();
    }
}

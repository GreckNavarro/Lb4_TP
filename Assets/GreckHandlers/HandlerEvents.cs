using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObjects/HandlerEventsPoints", order = 1)]
public class HandlerEvents : ScriptableObject
{
    public event Action<int> eventScriptableObject;
    
    public void InvokeAction(int value)
    {
        eventScriptableObject?.Invoke(value);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dummy : MonoBehaviour
{
    public void Test(InputAction.CallbackContext contex)
    {
        Debug.Log(contex);
    }
}

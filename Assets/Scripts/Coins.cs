using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] HandlerEvents GainPoints;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GainPoints.InvokeAction(value);
            Destroy(gameObject);
        }
    }
}

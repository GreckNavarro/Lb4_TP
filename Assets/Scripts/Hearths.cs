using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearths : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] HandlerEvents ModifyHealth;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ModifyHealth.InvokeAction(value);
            Destroy(gameObject);
        }
    }
}

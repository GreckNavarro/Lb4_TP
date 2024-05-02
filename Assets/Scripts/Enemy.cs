using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform[] pivots;
    [SerializeField] int damage;
    [SerializeField] private int velocity;
    [SerializeField] private int currentTargetIndex = 0;
    [SerializeField] HandlerEvents ModifyHealth;






    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (pivots == null || pivots.Length == 0)
        {
            return;
        }

        Transform nextTarget = pivots[currentTargetIndex];

        Vector2 moveDirection = (nextTarget.position - transform.position).normalized;
        float distanceToTarget = Vector2.Distance(transform.position, nextTarget.position);

        transform.Translate(moveDirection * velocity * Time.deltaTime);

        if (distanceToTarget < 0.1f)
        {
            currentTargetIndex = (currentTargetIndex + 1) % pivots.Length; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<SpriteRenderer>().color != gameObject.GetComponent<SpriteRenderer>().color)
            {
                ModifyHealth.InvokeAction(-damage);
            }
        }
    }

}

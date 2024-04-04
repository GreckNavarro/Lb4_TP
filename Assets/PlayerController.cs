using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int velocity;
    [SerializeField] private float axis;
    
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] SpriteRenderer mySR;


    [Header("Jump")]
    [SerializeField] private float jumpInpulse;
    [SerializeField] private bool isJumping;
    [SerializeField] private LayerMask myLayerMask;
    [SerializeField] private int saltos;


    private bool hasJumped = false;



    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        mySR = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MovementPlayer();
        OnValidateJump();
    }


    public void Movement(InputAction.CallbackContext value)
    {
        axis = value.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            if ((isJumping == false && saltos > 0) || (isJumping == true && saltos > 0))
            {
                myRB.AddForce(new Vector2(0, jumpInpulse));
                hasJumped = true;
                saltos -= 1;
                Debug.Log(saltos);
            }
        }
      

    }

    private void OnValidateJump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, myLayerMask);
        Debug.DrawRay(transform.position, Vector2.down * 0.5f, Color.green);
        if (hit.collider != null)
        {
            isJumping = false;

            if (hasJumped)
            {
                saltos = 2;
                hasJumped = false;
            }

        }
        else
        {
            isJumping = true;
        }

    }
    private void MovementPlayer()
    {
        myRB.velocity = new Vector2(axis * velocity, myRB.velocity.y);
    }

}

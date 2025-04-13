using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody playerRB;      //ref to player's RB
    
    private float moveSpeed = 4.0f;     //how quickly player moves around
    private float attackCooldown, attackWaitTime = 0.3f;     //where the cooldown currently is, the time to wait between hits

    //init base variables
    void Start()
    {
        //allow playe to do anything during the first frame
        attackCooldown = 0.0f;  
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetButton("Fire1") && attackCooldown <= 0)
            Attack();
        else
            attackCooldown -= Time.deltaTime;   //countdown
    }

    //move player around
    void MovePlayer()
    {
        //get the X and Z movement directions from input axis
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        
        //convert to a vector (Y not used)
        Vector3 movementVector = new Vector3(moveX * moveSpeed, 0.0f, moveZ * moveSpeed);

        //move player based on the input
        playerRB.velocity = movementVector;
    }

    //attack or destroy objects
    void Attack()
    {
        //do stuffs
        Debug.Log("Bonk!");

        //reset cooldown
        attackCooldown = attackWaitTime;
    }
}

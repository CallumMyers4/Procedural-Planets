using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody playerRB;      //ref to player's RB
    
    private float moveSpeed = 4.0f;     //how quickly player moves around

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetButton("Fire"))
            Attack();
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
    }
}

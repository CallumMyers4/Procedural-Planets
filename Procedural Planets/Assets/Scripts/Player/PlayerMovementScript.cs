using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    //references
    public Rigidbody playerRB;      //ref to player's RB
    
    //movement vars
    private float moveSpeed = 4.0f;     //how quickly player moves around

    //attacking vars
    private float attackCooldown, attackWaitTime = 1.3f;     //where the cooldown currently is, the time to wait between hits
    private bool attacking = false;

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
        attacking = true;   //tell script player is attacking
        attackCooldown = attackWaitTime;            //reset cooldown

        StartCoroutine(EndAttack());    //reset attack vars
    }

    IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.1f);  //give time to attack
        attacking = false;
    }

    void OnCollisionStay(Collision collision)
    {
        //if colliding with something that can be hit (so trees, rocks, etc.)
        if (collision.gameObject.CompareTag("Hittable"))
        {
            //if player is currently trying to attack
            if (attacking)
            {
                //do stuffs
                Debug.Log("Bonk!"); 

                collision.gameObject.GetComponent<ObjectManagerScript>().HP--;  //remove HP
            }
        }
    }
}

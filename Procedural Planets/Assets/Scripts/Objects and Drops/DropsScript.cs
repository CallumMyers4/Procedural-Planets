using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsScript : MonoBehaviour
{
    public InventoryItem dropItem;  //the item to add to the inventory
    [SerializeField]
    private int dropAmount;     //the number of items to add to the inventory
    private InventoryManager inventory;     //reference to the player's inventory

    public void Start()
    {
        //fill the ref using the inventory manager found in the scene
        inventory = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player has walked over the item
        if (other.gameObject.CompareTag("Player"))
        {
            inventory.AddToInventory(dropItem, dropAmount);
            Destroy(gameObject);    //destroy self
        }
    }
}

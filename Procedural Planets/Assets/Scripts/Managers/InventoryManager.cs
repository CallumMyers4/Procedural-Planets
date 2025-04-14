using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // Struct to store data for each item within the inventory
    [System.Serializable]
    private struct ItemInInventory
    {
        public InventoryItem item; // the item
        public int stack;   //how many are being held

        public ItemInInventory(InventoryItem item, int stack)
        {
            this.item = item;
            this.stack = stack;
        }
    }

    private List<ItemInInventory> inventoryItems = new List<ItemInInventory>();     //list of what player has currently

    //add a new item to the inventory
    public void AddToInventory(InventoryItem itemToAdd, int quantity)
    {
        //check all current inventory items
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            //if the item being added is found in the stack AND is not already a full stack
            if (inventoryItems[i].item == itemToAdd &&
                    inventoryItems[i].stack < itemToAdd.maxStack)
            {
                var currentItem = inventoryItems[i];    //make a temp copy of the current position in the list
                currentItem.stack += quantity;          //add the correct quantity to the stack
                inventoryItems[i] = currentItem;        //replace with modified values
                return;
            }
        }

        //if the item is not already there, or stack is full, then add a new stack
        inventoryItems.Add(new ItemInInventory(itemToAdd, quantity));
    }
}

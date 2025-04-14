using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject itemSlot;    //the prefab to create a new slot from
    [SerializeField]
    private Transform slotContainer;

    private List<InventorySlotScript> slots = new List<InventorySlotScript>();  //the list containing all slots
    private const int inventorySize = 28;   //the max number of items

    private void Awake()
    {
        //fill the inventory originally
        for (int i = 0; i < inventorySize; i++)
        {
            GameObject slot = Instantiate(itemSlot, slotContainer);     //create a new instance of a slot
            var newSlot = slot.GetComponent<InventorySlotScript>();     //get a reference to its script
            newSlot.ClearSlot();    //start vars as empty
            slots.Add(newSlot);     //add to list
        }
    }

    //update the UI
    public void RefreshUI(List<InventoryManager.ItemInInventory> inventoryItems)
    {
        //run over all items
        for (int i = 0; i < slots.Count; i++)
        {
            //if the slot is still within the size of the items list from the manager
            if (i < inventoryItems.Count)
            {
                //update the slot
                slots[i].SetSlot(inventoryItems[i].item, inventoryItems[i].stack);
            }
            else
            {
                //empty the slot if there is nothing there
                slots[i].ClearSlot();
            }
        }
    }
}

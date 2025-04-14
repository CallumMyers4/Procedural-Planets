using UnityEngine;

//stores data about items in the inventory
[CreateAssetMenu(fileName = "Inventory Item", menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string iName;    //name of the item
    public string description;      //a short description
    public Sprite sprite;   //image to be displayed in GUI
    public int maxStack;    //how many to hold per slot
}

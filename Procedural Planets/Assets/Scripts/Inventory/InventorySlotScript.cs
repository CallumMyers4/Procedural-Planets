using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class InventorySlotScript : MonoBehaviour
{
    [SerializeField]
    private Image itemSprite;   //the image on the slot
    [SerializeField]
    private TextMeshProUGUI stackText, nameText;  //the stack count text, the name of the material

    //update the slot (the item to add, the size of the stack)
    public void SetSlot(InventoryItem item, int stack)
    {
       // itemSprite.sprite = item.sprite;
       // itemSprite.enabled = true;
       stackText.text = stack.ToString();
       nameText.text = item.iName;
    }

    //remove the slot 
    public void ClearSlot()
    {
        itemSprite.sprite = null;
        itemSprite.enabled = false;
        stackText.text = "";
        nameText.text = "";
    }}

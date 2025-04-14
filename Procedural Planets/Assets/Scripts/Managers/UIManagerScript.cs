using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy);
        }
    }
}

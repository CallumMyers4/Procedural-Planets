using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ObjectManagerScript : MonoBehaviour
{
    public int HP;  //times getting hit before being destroyed

    [System.Serializable]
    public class Drops      //vars for each material drop
    {
        public string name;     //name of item
        public GameObject prefab;       //material prefab
        public int min;     //minimum number of mats
        public int max;     //maximum number of drops
    }

    public List<Drops> dropList;    //list of available drops for this object

    void Update()
    {
        if (HP <= 0)
           DestroyAndDrop();
    }

    //destroy the object and drop the appropriate materials
    void DestroyAndDrop()
    {

    }
}

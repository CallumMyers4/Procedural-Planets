using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class ObjectManagerScript : MonoBehaviour
{
    public int HP = 3;  //times getting hit before being destroyed

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
        //for each possible material in the list
        for (int i = 0; i < dropList.Count; i++)
        {
            //decide how many to drop between the min and max possible
            int spawnCount = Random.Range(dropList[i].min, dropList[i].max);

            //spawn the appropriate number around the object
            for (int j = 0; j < spawnCount; j++)
            {
                //get an X and Z offset from the object
                int xOffset = Random.Range(-2, 2);
                int zOffset = Random.Range(-1, 1);

                Instantiate(dropList[i].prefab, new Vector3
                                            (transform.position.x + xOffset, transform.position.y, transform.position.z + zOffset), 
                            Quaternion.identity);
            }
        }

        Destroy(gameObject);
    }
}

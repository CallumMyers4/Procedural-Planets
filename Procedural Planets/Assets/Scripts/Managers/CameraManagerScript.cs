using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManagerScript : MonoBehaviour
{
    public GameObject target;   //reference to target object

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
    }
}

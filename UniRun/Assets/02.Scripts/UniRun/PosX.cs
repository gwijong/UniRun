using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosX : MonoBehaviour
{
    public float posx = -6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(posx, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}

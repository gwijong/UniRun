using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerChange : MonoBehaviour
{
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if (time >=0f && time < 0.3f)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "BackGround";
        }else if (time > 0.3f && time < 0.6f)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Forground";
        }
        else
        {
            time = 0;
        }
    }
}

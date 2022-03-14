using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    bool up = false;
    bool corutine = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(corutine == false)
        {
            corutine = true;
            StartCoroutine("Updown");
        }
        if (up ==true)
        {
            gameObject.transform.Translate(0, 1 * Time.deltaTime * speed, 0);
        }
        else
        {
            gameObject.transform.Translate(0, -1 * Time.deltaTime * speed, 0);
        }
    }

    IEnumerator Updown()
    {
        yield return new WaitForSeconds(2.0f);
        up = true;
        yield return new WaitForSeconds(2.0f);
        up = false;
        corutine = false;
    }
}

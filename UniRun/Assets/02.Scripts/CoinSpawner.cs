using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    float time = 0;
    public GameObject coin;
    public GameObject FeverCheck;
    public bool fever = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FeverCheck != null)
        {
            fever = FeverCheck.GetComponent<Fever>().isFever;
        }
        time = time + Time.deltaTime;
        if (time >= 0.2f && fever)
        {
            time = 0;
            if (coin != null)
            {
                GameObject go = Instantiate(coin);
                go.transform.position = this.transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sim_LaserAttack : MonoBehaviour
{
    public GameObject LaserParticle;
    public GameObject Warning;
    bool flag1 = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flag1 == false)
        {
            flag1 = true;

            StartCoroutine("LaserAttack");
        }
    }
    IEnumerator LaserAttack()
    {
        yield return new WaitForSeconds(10.0f);
        Warning.SetActive(true);
        for(int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                Warning.SetActive(false);
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                Warning.SetActive(true);
                yield return new WaitForSeconds(0.1f);
            }
        }
        Warning.SetActive(false);
        LaserParticle.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        LaserParticle.SetActive(false);
        flag1 = false;
    }
}

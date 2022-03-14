using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HitEffect : MonoBehaviour
{
    public GameObject player;
    bool coroutine = false;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().hit == true && coroutine ==false)
        {
            coroutine = true;
            StartCoroutine("Hit");
        }
    }
    IEnumerator Hit()
    {

        gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        for (int i = 0; i<100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, (float)(100-i)/100);
        }
        gameObject.GetComponent<Image>().color = new Color(1,1,1,0);
        coroutine = false;

    }
}

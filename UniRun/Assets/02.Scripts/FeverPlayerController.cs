using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverPlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)  //트리거 콜라이더를 가진 장애물과의 충돌을 감지
    {

        if (collision.tag == "Coin")
        {
            GameManager.instance.AddScore(5);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (collision.tag == "Potion")
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }

        if (collision.tag == "Portal")
        {
            collision.GetComponent<LoadScene>().SceneLoad();
        }
    }
}

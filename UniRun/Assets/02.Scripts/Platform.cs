using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles; // 장애물 오브젝트들
    public GameObject[] coins;
    private bool stepped = false; // 플레이어 캐릭터가 밟았는가


    private void OnEnable() // 컴포넌트가 활성화될 때마다 매번 실행되는 메서드
    {
        stepped = false; //밟힘 상태를 리셋

        for (int i = 0; i<obstacles.Length; i++)
        {
            if(Random.Range(0,3) == 0) //현재 순번의 장애물을 3분의 1 확률로 활성화
            {
                obstacles[i].SetActive(true);
                coins[i].SetActive(true);
                coins[i].GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                obstacles[i].SetActive(false);
                coins[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //발판을 리셋하는 처리
    {
        // 플레이어 캐릭터가 자신을 밟았을때 점수를 추가하는 처리
        if(collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}

using UnityEngine;

public class PlatformSpawner : MonoBehaviour  //발판을 생성하고 주기적으로 재배치하는 스크립트
{
    public GameObject platformPrefab;  // 생성할 발판의 원본 프리팹
    public int count = 3;  //생성할 발판 수

    float timeBetSpawnMin = 1.25f;  //다음 배치까지의 시간 간격 최솟값
    float timeBetSpawnMax = 2.25f;  //다음 배치까지의 시간 간격 최댓값
    float timeBetSpawn;  // 다음 배치까지의 시간 간격

    public float yMin = -3.5f;  // 배치할 위치의 최소 y 값
    public float yMax = 1f;  // 배치할 위치의 최대 y 값
    float xpos = 25f;  //배치할 위치의 x 값

    GameObject[] platforms; //미리 생성한 발판들
    int currentIndex = 0;  // 사용할 현재 순번의 발판

    Vector2 poolPosition = new Vector2(-15, -25);  //초반에 생성한 발판을 화면 밖에 숨겨둘 위치
    float lastSpawnTime;  // 마지막 배치 시점
    public GameObject feverObj;

    void Start()  //변수를 초기화하고 사용할 발판을 미리 생성
    {
        if (platformPrefab != null)
        {
            platforms = new GameObject[count];

            for (int i = 0; i < count; i++)
            {
                platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);
            }
        }
        lastSpawnTime = 0f;
    }

    void Update()  // 순서를 돌아가며 주기적으로 발판을 배치
    {
       
        if (GameManager.instance.isGameover)
        {
            return;
        }
        /*
        if (GameObject.FindWithTag("Player")!=null)
        {
            if(GameObject.FindWithTag("Player").GetComponent<PlayerController>().hit == true)
            {
                return;
            }
        }
        */
        if (Time.time >lastSpawnTime + timeBetSpawn)  //마지막 배치 시점에서 timeBetSpawn 이상 시간이 흘렀다면
        {
            lastSpawnTime = Time.time; //기록된 마지막 배치 시점을 현재 시점으로 갱신

            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);  //다음 배치까지의 시간 간격을 랜덤 설정

            float yPos = Random.Range(yMin, yMax);  //배치할 위치의 높이를 랜덤 설정

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xpos, yPos); //현재 순번의 발판을 화면 오른쪽에 재배치

            currentIndex++; //순번 넘기기

            if(currentIndex >= count)  //마지막 순번에 도달했다면 순번을 리셋
            {
                currentIndex = 0;
            }
        }
    }
}

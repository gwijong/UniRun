using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour  //플레이어 캐릭터로서 Player 게임 오브젝트를 제어함
{
    public AudioClip deathClip;  //사망 시 재생할 오디오 클립
    public float JunpForce = 700f;  //점프 힙

    private int jumpCount = 0;  //누적 점프 횟수
    private bool isGruonded = false;  //바닥에 닿았는지 나타냄
    private bool isDead = false;  //사망 상태
    private Rigidbody2D playerRigidbody;  //사용할 리지드바디 컴포넌트
    private Animator animator;  //사용할 애니메이터 컴포넌트
    private AudioSource playerAudio;  // 사용할 오디오 소스 컴포넌트
    [SerializeField]
    private int hp = 2;
    public GameObject hp1;
    public GameObject hp2;
    void Start()
    {   
        //초기화
        //게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    void Update()  //사용자 입력을 감지하고 점프하는 처리
    {

        if (isDead)
        {
            // 사망 시 처리를 더 이상 진행하지 않고 종료
            return;
        }

        if (hp == 2)
        {
            hp2.SetActive(true);
            hp1.SetActive(true);
        }

        if (hp == 1)
        {
            hp2.SetActive(false);
            hp1.SetActive(true);
        }

        if (hp == 0)
        {
            hp2.SetActive(false);
            hp1.SetActive(false);
        }

        if (hp < 0)
        {
            Die();
            hp2.SetActive(false);
            hp1.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 2)// 마우스 왼쪽 버튼을 눌렀으며 최대 점프 횟수에 도달하지 않았다면
        {
            jumpCount++; //점프 횟수 증가
            playerRigidbody.velocity = Vector2.zero;//점프 직전에 속도를 순간적으로 제로로 변경
            playerRigidbody.AddForce(new Vector2(0, JunpForce));//리지드바디에 위쪽으로 힘 주기
            playerAudio.Play();//오디오소스 재생
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)//마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y값이 양수라면(위로 상승 중)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;//현재 속도를 절반으로 변경
        }
        animator.SetBool("Grounded", isGruonded); //애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
    }

    private void Die()
    {
        animator.SetTrigger("Die");// 애니메이터의 Die 트리거 파라미터를 셋
        playerAudio.clip = deathClip;  //오디오소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.Play();  //사망 효과음 재생
        playerRigidbody.velocity = Vector2.zero;  //속도를 제로로 변경
        playerRigidbody.gravityScale = 0;
        isDead = true;  //사망 상태를 true로 변경
        GameManager.instance.OnPlayerDead();
        StartCoroutine("Destroy");
    }

    private void OnTriggerEnter2D(Collider2D collision)  //트리거 콜라이더를 가진 장애물과의 충돌을 감지
    {
        if(collision.tag == "Dead" && !isDead)  //충돌한 상대방의 태그가 Dead이며 아직 사망하지 않았다면
        {
            Die();
            hp2.SetActive(false);
            hp1.SetActive(false);
        }
        
        if(collision.tag == "Hit" && !isDead)
        {
            hp = hp - 1;
        }

        if (collision.tag == "Coin" && !isDead)
        {
            GameManager.instance.AddScore(5);
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  // 바닥에 닿았음을 감지하는 처리
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGruonded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)  // 바닥에서 벗어났음을 감지하는 처리
    {
        isGruonded = false;
    }
    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.8f);
        this.gameObject.SetActive(false);
    }
}

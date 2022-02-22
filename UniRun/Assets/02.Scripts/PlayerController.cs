using UnityEngine;

public class PlayerController : MonoBehaviour  //�÷��̾� ĳ���ͷμ� Player ���� ������Ʈ�� ������
{
    public AudioClip deathClip;  //��� �� ����� ����� Ŭ��
    public float JunpForce = 700f;  //���� ��

    private int jumpCount = 0;  //���� ���� Ƚ��
    private bool isGruonded = false;  //�ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false;  //��� ����
    private Rigidbody2D playerRigidbody;  //����� ������ٵ� ������Ʈ
    private Animator animator;  //����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio;  // ����� ����� �ҽ� ������Ʈ

    void Start()
    {   
        //�ʱ�ȭ
        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }


    void Update()  //����� �Է��� �����ϰ� �����ϴ� ó��
    {
        if (isDead)
        {
            // ��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }

        if(Input.GetMouseButtonDown(0) && jumpCount < 2)// ���콺 ���� ��ư�� �������� �ִ� ���� Ƚ���� �������� �ʾҴٸ�
        {
            jumpCount++; //���� Ƚ�� ����
            playerRigidbody.velocity = Vector2.zero;//���� ������ �ӵ��� ���������� ���η� ����
            playerRigidbody.AddForce(new Vector2(0, JunpForce));//������ٵ� �������� �� �ֱ�
            playerAudio.Play();//������ҽ� ���
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)//���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y���� ������(���� ��� ��)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;//���� �ӵ��� �������� ����
        }
        animator.SetBool("Grounded", isGruonded); //�ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
    }

    private void Die()
    {
        animator.SetTrigger("Die");// �ִϸ������� Die Ʈ���� �Ķ���͸� ��
        playerAudio.clip = deathClip;  //������ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.Play();  //��� ȿ���� ���
        playerRigidbody.velocity = Vector2.zero;  //�ӵ��� ���η� ����
        isDead = true;  //��� ���¸� true�� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)  //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    {
        if(collision.tag == "Dead" && !isDead)  //�浹�� ������ �±װ� Dead�̸� ���� ������� �ʾҴٸ�
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  // �ٴڿ� ������� �����ϴ� ó��
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGruonded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)  // �ٴڿ��� ������� �����ϴ� ó��
    {
        isGruonded = false;
    }
}

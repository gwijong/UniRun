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
    // Start is called before the first frame update
    void Start() //�ʱ�ȭ
    {
        
    }

    // Update is called once per frame
    void Update()  //����� �Է��� �����ϰ� �����ϴ� ó��
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)  //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)  // �ٴڿ� ������� �����ϴ� ó��
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)  // �ٴڿ��� ������� �����ϴ� ó��
    {
        
    }
}

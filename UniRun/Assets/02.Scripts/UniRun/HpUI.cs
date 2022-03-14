using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpUI : MonoBehaviour
{
    public Image hpSlider;
    public Image backHpSlider;
    public float maxHp;
    public float currentHp;
    public PlayerController player;
    public static bool backHpHit = false;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        maxHp = player.MaxHp;
        currentHp = player.Hp;
        hpSlider.fillAmount = Mathf.Lerp(hpSlider.fillAmount, currentHp / maxHp, Time.deltaTime * 5f);
        if (player.hit&&backHpHit==false)
        {
            StartCoroutine("Hit");
        }
        if (backHpHit)
        {
            backHpSlider.fillAmount = Mathf.Lerp(backHpSlider.fillAmount, currentHp / maxHp, Time.deltaTime * 10f);
            if(hpSlider.fillAmount >= backHpSlider.fillAmount - 0.01f)
            {
                backHpHit = false;
                backHpSlider.fillAmount = hpSlider.fillAmount;
            }
        }
    }
    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.5f);
        backHpHit = true;
    }

}




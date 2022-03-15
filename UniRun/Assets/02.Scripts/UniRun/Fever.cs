using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Fever : MonoBehaviour
{
    public Image feverSlider;
    float feverGage = 0f;
    public bool isFever = false;
    public GameObject Player;
    public GameObject FeverPlayer;
    public Text FeverText;
    public GameObject StartPlatform;
    // Update is called once per frame
    void Update()
    {
        feverSlider.fillAmount = feverGage;
        if (feverGage < 1 && isFever == false)
        {
            AddFeverGage(0.1f * Time.deltaTime);
        }
        else if(feverGage >= 1 && isFever == false && !GameManager.instance.isGameover)
        {
            isFever = true;
            StartCoroutine("FeverStart");
        }
        if (GameManager.instance.isGameover)
        {
            StopCoroutine("FeverStart");
            FeverPlayer.SetActive(false);
            FeverText.gameObject.SetActive(false);
        }

    }

    public void AddFeverGage(float add)
    {
        feverGage = feverGage + add;
    }

    IEnumerator FeverStart()
    {
        yield return new WaitForSeconds(0.1f);
        FeverText.gameObject.SetActive(true);
        ScrollingObject.speed = 30.0f;
        feverGage = 0.0f;
        Player.SetActive(false);
        FeverPlayer.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        isFever = false;
        Player.SetActive(true);
        Player.GetComponent<Transform>().position = new Vector3(-6, 5, 0);
        FeverPlayer.SetActive(false);
        ScrollingObject.speed = 10.0f;
        FeverText.gameObject.SetActive(false);
        GameObject go = Instantiate(StartPlatform);
        go.transform.position = new Vector3(-6,-0.6f,0);
    }
}

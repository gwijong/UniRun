using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading_Scene : MonoBehaviour
{
    public Image GaugeBar;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadingScene");

    }

    IEnumerator LoadingScene()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync("Level_1");
        oper.allowSceneActivation = false;

        float timer = 0.01f;
        while (!oper.isDone)
        {
            yield return new WaitForSeconds(0.01f);
            timer += Time.deltaTime;

            if (oper.progress >= .9f)
            {
                GaugeBar.fillAmount = Mathf.Lerp(GaugeBar.fillAmount, 1f, timer);
                text.text = (oper.progress * 100f) + 10f + "%";

                if (GaugeBar.fillAmount == 1.0f)
                    oper.allowSceneActivation = true;
            }
            else
            {
                text.text = (oper.progress * 100f) + 10f + "%";
                GaugeBar.fillAmount = Mathf.Lerp(GaugeBar.fillAmount, oper.progress, timer);
                if (GaugeBar.fillAmount >= oper.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}

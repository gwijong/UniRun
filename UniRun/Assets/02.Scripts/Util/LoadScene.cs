using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;
    public void SceneLoad()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}


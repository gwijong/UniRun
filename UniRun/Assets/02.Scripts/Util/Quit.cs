using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public void GameQuit()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }
}

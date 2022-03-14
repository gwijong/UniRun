using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject Player;
    public float division = 3.0f;
    public float plus = 7.0f;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Camera>().orthographicSize = Player.transform.position.y/division + plus;
    }
}

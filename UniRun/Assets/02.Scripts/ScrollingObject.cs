using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public static float speed = 10f;
    public static bool scrollingStop = false;
    void Start()
    {
        
    }

   
    void Update()
    {

        if (!GameManager.instance.isGameover && !scrollingStop)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEffect : MonoBehaviour
{
    public GameObject Particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine("Potion");
        }
    }
    IEnumerator Potion()
    {
        Particle.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Particle.SetActive(false);
    }
}

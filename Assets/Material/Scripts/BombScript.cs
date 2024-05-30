//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int timer = 15;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blade2 blade = other.GetComponent<Blade2>();
            FindObjectOfType<GameManager>().Explode(timer);
        }
    }
}

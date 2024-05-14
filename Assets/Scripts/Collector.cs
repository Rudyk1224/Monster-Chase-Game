using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    //In this case, gameObject = the collector (the walls at the edge of the map)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
            Destroy(collision.gameObject); //destroy the enemy (collision is thing that is being collided with the walls, which is enemy)
    }
}

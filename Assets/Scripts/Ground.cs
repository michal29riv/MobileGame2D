using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") == true || collision.CompareTag("Collectible") == true)
        {
            Destroy(collision.gameObject);
        }
    }
}

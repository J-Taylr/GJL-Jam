using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZone : MonoBehaviour
{

    public bool playerInZone = true;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("outside");
            playerInZone = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("inside");
            playerInZone = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("stay");
            playerInZone = true;
        }
    }
    
}

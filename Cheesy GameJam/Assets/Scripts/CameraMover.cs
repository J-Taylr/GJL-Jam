using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Components")]
    
    public float scrollSpeed = 0.1f;
    Vector3 targetPos;
    GameObject player;
    CamZone camZone;
    public bool inZone;

    Vector3 velocity; //reference
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camZone = GetComponentInChildren<CamZone>();
    }

  

    private void FixedUpdate()
    {
        if (!camZone.playerInZone)
{
            targetPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, scrollSpeed);
        }
    }

    

  
}

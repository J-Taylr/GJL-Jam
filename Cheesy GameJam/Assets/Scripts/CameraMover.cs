using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    
    
    public float scrollSpeed = 0.1f;
    Vector3 targetPos;
    GameObject player;

    

    Vector3 velocity; //reference
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        targetPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, scrollSpeed);
    }

    

  
}

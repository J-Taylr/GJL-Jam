using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [Header("Components")]
    Vector3 targetPos;
    GameObject player;
    public CamZone safeCamZone;
    public CamZone dangerCamZone;
    
    [Header("Variables")]
    public float ScrollHolder = 0.1f;
    public float ScrollRead;
    public bool moveCam;
    public bool dangerCam;

    Vector3 velocity; //reference
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        CheckCamZones();
    }

    public void CheckCamZones()
    {
        if (safeCamZone.playerInZone)
        {
            dangerCam = false;
        }

        if (!safeCamZone.playerInZone)
        {
            moveCam = true;
            ScrollRead = ScrollHolder;

            if (!dangerCamZone.playerInZone && !dangerCam)
            {
                ScrollRead = (ScrollHolder / 4);
                dangerCam = true;
            }
        }

      
    }

    private void FixedUpdate()
    {
        if (moveCam)
        {
            targetPos = new Vector3(player.transform.position.x, player.transform.position.y, -10);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, ScrollRead);

            if (Vector2.Distance(transform.position, player.transform.position) <= 0.1f)
            {
                moveCam = false;
            }
        }


    }

    

  
}

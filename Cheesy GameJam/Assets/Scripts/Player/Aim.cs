using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector2 offset;
    public float angle;
    Camera cam;
    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        GetMousePos();
    }


    public void GetMousePos()
    {
        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = cam.WorldToScreenPoint(transform.position);

        offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, (angle - 90));


       /* if (angle > 90 || angle < -90)
        {
            transform.localRotation = Quaternion.Euler(180, 90, angle);
            
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0f, 180, -angle);
            
        }
       */

    }

}

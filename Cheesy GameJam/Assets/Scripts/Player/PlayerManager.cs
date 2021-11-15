using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health = 3;

    public void Update()
    {
        if (health == 0)
        {
            Debug.Log("You're Dead");
        }
    }
}

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
            GameManager.Instance.gameActive = false;

            Debug.Log("You're Dead");
        }
    }
}

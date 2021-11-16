using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        //DontDestroyOnLoad(this.gameObject);
    }
    //starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere//starthere

    bool gameActive = true;
    [Header("Score & Time")]
    public Text textTimer;
    public float time = 0;
    public int PlayerScore = 0;
    float minutes;
    float seconds;
    float milliseconds;





    private void Update()
    {
        if (gameActive)
        {
            time += Time.deltaTime;
        }
        DisplayTime(time);
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

         minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        milliseconds = (timeToDisplay % 1) * 1000;


        textTimer.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }


    public void AddPoints(int points)
    {
        PlayerScore += points;
    }
}

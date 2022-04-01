using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TMP_Text TimerText;
    public bool TimerIsActive;
    public Toggle ToggleChrono;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if(TimerIsActive == true)
        {
            DisplayTime(timeRemaining);
            timerIsRunning = true;
        }
        else if(TimerIsActive == false)
        {
            TimerText.text = string.Format("--------");
            timerIsRunning = false;
        }
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        if(ToggleChrono.isOn == true)
        {
            TimerIsActive = true;
        }
        else if(ToggleChrono.isOn == false)
        {
            TimerIsActive = false;
        }
    }

    

    void DisplayTime(float timeToDisplay)
    {
  float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
  float seconds = Mathf.FloorToInt(timeToDisplay % 60);
  TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

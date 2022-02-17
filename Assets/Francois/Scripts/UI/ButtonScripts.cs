using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    [SerializeField] private Button QuitApp;
    [SerializeField] private Button PlayAndPause;
    [SerializeField] private Button Penaliter;


    private bool IsOnPause;
    private Timer TheTimer;

    private void Awake() {
        Time.timeScale = 0;
        IsOnPause = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        TheTimer = GameObject.Find("Timer").GetComponent<Timer>();
        QuitApp.onClick.AddListener(QuitTheApp);
        PlayAndPause.onClick.AddListener(PauseTimer);
        Penaliter.onClick.AddListener(PenaliterTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOnPause == false)
        {
            PlayAndPause.onClick.AddListener(PauseTimer);
        }
        else if(IsOnPause == true)
        {
            PlayAndPause.onClick.AddListener(PlayTimer);
        }
    }

    void QuitTheApp()
    {
        Application.Quit();
    }

    void PauseTimer()
    {
        Time.timeScale = 0;
        IsOnPause = true;
   }

    void PlayTimer()
    {
        Time.timeScale = 1;
        IsOnPause = false;
    }

    void PenaliterTimer()
    {
        TheTimer.timeRemaining -= (180);
    }
}

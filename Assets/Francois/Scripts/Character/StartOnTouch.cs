using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOnTouch : MonoBehaviour
{
    private Button  StartButton;

    private void Awake() {
        StartButton = gameObject.GetComponent<Button>();
        Time.timeScale = 0;
    }

    private void Start() {
        StartButton.onClick.AddListener(TouchScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TouchScreen()
    {
        Time.timeScale = 1;
        Destroy(this.gameObject);
    }
}

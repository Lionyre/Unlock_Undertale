using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaveGame : MonoBehaviour
{
    private Button LeaveButton;
    // Start is called before the first frame update
    void Start()
    {
        LeaveButton = this.gameObject.GetComponent<Button>();
        LeaveButton.onClick.AddListener(LeaveTheGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LeaveTheGame()
    {
        SceneManager.UnloadSceneAsync("FrancoisMinigame");
        GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangementDeSceneScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("FrancoisMinigame", LoadSceneMode.Additive);
            GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = false;
        }
    }
}

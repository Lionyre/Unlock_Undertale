using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadButton : MonoBehaviour
{
    

    void Start()
    {
        
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("Machine Papyrus");

    }


    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiButton : MonoBehaviour
{
    public void QuitGame(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }

    public void RestartGame(string name)
    {
        SceneManager.UnloadSceneAsync(name);
        SceneManager.LoadScene(name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    public string level;
    public void LoadLevel()
    {
        SceneManager.LoadScene(level);
    }
}

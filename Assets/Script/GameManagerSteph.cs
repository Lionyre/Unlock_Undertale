using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerSteph : MonoBehaviour
{
    public int _counter = 0;
    public int _tileNumber = 8;

    public GameObject _canvasVictoire;

    public GameObject _tileParent;
    private EnterMachine Machine;


    private void Start()
    {
        Time.timeScale = 1;
        _canvasVictoire.SetActive(false);
        _tileNumber = _tileParent.GetComponentsInChildren<Collider2D>().Length;
        Machine = GameObject.Find("EnterMachine").GetComponent<EnterMachine>();

    }

    private void Update()
    {
        if (_counter == _tileNumber)
        {
            Machine.finished[Machine.selection] = true;
            Machine.Victiore.SetActive(true);
            GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = true;
            SceneManager.UnloadSceneAsync("Machine Papyrus");
        }

    }

    
}

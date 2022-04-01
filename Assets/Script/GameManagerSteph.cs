using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSteph : MonoBehaviour
{
    public int _counter = 0;
    public int _tileNumber = 8;

    public GameObject _canvasVictoire;

    public GameObject _tileParent;


    private void Start()
    {
        _canvasVictoire.SetActive(false);
        _tileNumber = _tileParent.GetComponentsInChildren<Collider2D>().Length;

    }

    private void Update()
    {
        if (_counter == _tileNumber)
        {
            Debug.Log("Victoire");

            _canvasVictoire.SetActive(true);

            Time.timeScale = 0f;
            
        }

    }

    
}

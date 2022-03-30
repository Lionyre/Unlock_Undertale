using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSteph : MonoBehaviour
{
    public int _counter = 0;
    public int _tileNumber = 8;

    public GameObject _tileParent;

    private void Update()
    {
        if (_counter == _tileNumber)
        {
            Debug.Log("Victoire");
        }

    }

    private void Start()
    {
        _tileNumber = _tileParent.GetComponentsInChildren<Collider2D>().Length;

    }
}

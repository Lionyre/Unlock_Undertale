using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailEnd : MonoBehaviour
{

    [SerializeField] AdamMove _adamMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "TriggersSnail")
        {
            Debug.Log("enemy Win");
            _adamMove._enemyWin = true;
        }
        else if (collision.gameObject.name == "TriggersPlayer")
        {
            Debug.Log("player Win");
            _adamMove._isEnded = true;
        }
    }
}

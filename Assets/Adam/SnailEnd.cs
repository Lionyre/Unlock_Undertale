using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailEnd : MonoBehaviour
{

    [SerializeField] AdamMove _adamMove;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("End");

        if (collision.gameObject.name == "EnemySnail")
        {
            Debug.Log("End");
            _adamMove._enemyWin = true;
        }
        else if (collision.gameObject.name == "Player")
        {
            Debug.Log("End");
            _adamMove._isEnded = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsnail : MonoBehaviour
{
    public GameObject _snailgame;
    public void RestartGame()
    {
        Instantiate(_snailgame, this.transform.parent);
        Destroy(this.gameObject);
    }
}

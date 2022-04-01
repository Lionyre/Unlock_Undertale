using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeathSteph : MonoBehaviour
{
    private PlayerPMove _player;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerPMove>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == _player.gameObject.name)
        {
            Debug.Log("PlayerDeath");

            SceneManager.LoadScene("Machine Papyrus");
        }
    }
}

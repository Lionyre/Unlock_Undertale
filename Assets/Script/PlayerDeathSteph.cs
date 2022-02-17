using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeathSteph : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        
        if (other.gameObject.name == _player.gameObject.name)
        {
            Debug.Log("PlayerDeath");

            SceneManager.LoadScene("Machine Papyrus");


            
        }
    }
}

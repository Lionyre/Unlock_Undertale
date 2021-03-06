using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orangeade : MonoBehaviour
{
    [SerializeField] private Player player = null;
    private AudioSource taste;
    private void Awake() 
    {
        taste = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 0 && other.gameObject.name == "Player")
        {
            taste.Play();
            player.orange = true;
        }
    }
}

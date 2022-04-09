using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green : MonoBehaviour
{
    private AudioSource moan;
    private void Awake() 
    {
        moan = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 0 && other.gameObject.name == "Player")
        {
            moan.Play();
        }
    }
}

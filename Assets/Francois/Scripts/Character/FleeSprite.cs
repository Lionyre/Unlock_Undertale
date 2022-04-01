using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeSprite : MonoBehaviour
{
    public Sprite HeartFlee;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Flee")
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Animator>().SetBool("TouchLayer", true);
        }
    }
}

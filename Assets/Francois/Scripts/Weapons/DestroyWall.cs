using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "LanceMur")
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}

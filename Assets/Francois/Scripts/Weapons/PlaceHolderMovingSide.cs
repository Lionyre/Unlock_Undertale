using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHolderMovingSide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TimerMovingSide");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimerMovingSide()
    {
        yield return new WaitForSeconds(15);
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPc : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            gameObject.transform.position += new Vector3(0,Speed,0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += new Vector3(0,-Speed,0);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            gameObject.transform.position += new Vector3(-Speed,0,0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(Speed,0,0);
        }
    }
}

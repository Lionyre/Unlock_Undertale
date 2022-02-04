using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithButton : MonoBehaviour
{
    public MovingHeart GetBool;
    [SerializeField] private float VitesseDeplacement;

    // Update is called once per frame
    void FixedUpdate()
    {
        BoolHell();
    }

    void BoolHell()
    {
        if(GetBool.IsOnClickUp == true)
        {
            transform.position += new Vector3(0,VitesseDeplacement,0);
        }
        else if(GetBool.IsOnClickDown == true)
        {
            transform.position += new Vector3(0,-VitesseDeplacement,0);
        }
        else if(GetBool.IsOnClickLeft == true)
        {
            transform.position += new Vector3(-VitesseDeplacement,0,0);
        }
        else if(GetBool.IsOnClickRight == true)
        {
           transform.position += new Vector3(VitesseDeplacement,0,0); 
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithButton : MonoBehaviour
{
    public MovingHeart GetBool;
    [SerializeField] private float VitesseDeplacement;
    public VariableJoystick variableJoystick;

    // Update is called once per frame
    void FixedUpdate()
    {
        BoolHell();
    }

    void BoolHell()
    {
        if(variableJoystick.Direction.y > 0.5)
        {
            transform.position += new Vector3(0,VitesseDeplacement,0);
        }
        else if(variableJoystick.Direction.y < -0.5)
        {
            transform.position += new Vector3(0,-VitesseDeplacement,0);
        }
        if(variableJoystick.Direction.x < -0.5)
        {
            transform.position += new Vector3(-VitesseDeplacement,0,0);
        }
        else if(variableJoystick.Direction.x > 0.5)
        {
           transform.position += new Vector3(VitesseDeplacement,0,0); 
        }
    }
}

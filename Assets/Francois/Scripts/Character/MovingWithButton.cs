using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWithButton : MonoBehaviour
{
    [SerializeField] private float VitesseDeplacement;
    private VariableJoystick variableJoystick;
    [SerializeField] private float DeadZone;

    private void Awake() {
        variableJoystick = GameObject.Find("Variable_Joystick").GetComponent<VariableJoystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BoolHell();
    }

    void BoolHell()
    {
        if(variableJoystick.Direction.y > DeadZone)
        {
            transform.position += new Vector3(0,VitesseDeplacement,0);
        }
        else if(variableJoystick.Direction.y < -DeadZone)
        {
            transform.position += new Vector3(0,-VitesseDeplacement,0);
        }
        if(variableJoystick.Direction.x < -DeadZone)
        {
            transform.position += new Vector3(-VitesseDeplacement,0,0);
        }
        else if(variableJoystick.Direction.x > DeadZone)
        {
           transform.position += new Vector3(VitesseDeplacement,0,0); 
        }
    }
}

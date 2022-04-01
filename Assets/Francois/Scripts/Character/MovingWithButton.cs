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
            gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
        }
        else if(variableJoystick.Direction.y < -DeadZone)
        {
            transform.position += new Vector3(0,-VitesseDeplacement,0);
            gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
        }
        if(variableJoystick.Direction.x < -DeadZone)
        {
            transform.position += new Vector3(-VitesseDeplacement,0,0);
            gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(variableJoystick.Direction.x > DeadZone)
        {
           transform.position += new Vector3(VitesseDeplacement,0,0);
           gameObject.GetComponent<Animator>().SetBool("IsMoving", true);
           gameObject.GetComponent<SpriteRenderer>().flipX = true; 
        }

        else
        {
            gameObject.GetComponent<Animator>().SetBool("IsMoving", false);
        }
    }
}

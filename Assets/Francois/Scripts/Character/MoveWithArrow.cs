using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithArrow : MonoBehaviour
{
    public MovingHeart GetBool;
    public PlayerPMove _playerPMove;

    [SerializeField] private float VitesseDeplacement;

    // Update is called once per frame
    void FixedUpdate()
    {
        BoolHell();

        _playerPMove.StayGlace();

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

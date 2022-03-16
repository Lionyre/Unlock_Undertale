using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Player player = null;
    public Animator walkn;
    public MovingHeart GetBool;

    void Up()
    {
        if(player.stopUp == false && player.stopAll == false && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
            transform.position += transform.up * player.speed *Time.deltaTime;
            walkn.Play("up");
        }
    }
    void Down()
    {
        if(player.stopDown == false && player.stopAll == false && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
            transform.position -= transform.up * player.speed *Time.deltaTime;
            walkn.Play("down");
        }
    }
    void Left()
    {
        if(player.stopLeft == false && player.stopAll == false){
            transform.position -= transform.right * player.speed *Time.deltaTime;
            walkn.Play("left");
        }
    }
    void Right()
    {
        if(player.stopRight == false && player.stopAll == false){
            transform.position += transform.right * player.speed *Time.deltaTime;
            walkn.Play("right");
        }
    }
    void BoolHell()
    {
        if(GetBool.IsOnClickUp == true)
        {
            Up();        
        }
        else if(GetBool.IsOnClickDown == true)
        {
            Down();
        }
        else if(GetBool.IsOnClickLeft == true)
        {
            Left();
        }
        else if(GetBool.IsOnClickRight == true)
        {
           Right();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Up();
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            Down();
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Right();
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
        }
        BoolHell();
    }
}

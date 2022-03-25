using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    [SerializeField] private Player player = null;
    public Animator walkn;
    public MovingHeart GetBool;
    public float avancement = 0;
    private bool X;


    
    void Up()
    {
        if(player.stopUp == false && player.stopAll == false && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
            //transform.position += transform.up * player.speed *Time.deltaTime;
            X = false;
            StartCoroutine(str8movin(new Vector3(0,0.1f,0)));
            walkn.Play("up");
        }
    }
    void Down()
    {
        if(player.stopDown == false && player.stopAll == false && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
            //transform.position -= transform.up * player.speed *Time.deltaTime;
            X = false;
            StartCoroutine(str8movin(new Vector3(0,-0.1f,0)));
            walkn.Play("down");
        }
    }
    void Left()
    {
        if(player.stopLeft == false && player.stopAll == false){
            //transform.position -= transform.right * player.speed *Time.deltaTime;
            X = true;
            StartCoroutine(str8movin(new Vector3(-0.1f,0,0)));
            walkn.Play("left");
        }
    }
    void Right()
    {
        if(player.stopRight == false && player.stopAll == false){
            //transform.position += transform.right * player.speed *Time.deltaTime;
            X = true;
            StartCoroutine(str8movin(new Vector3(0.1f,0,0)));
            walkn.Play("right");
        }
    }
    private IEnumerator str8movin(Vector3 direcfion)
    {
        Debug.Log("allo");   
        player.stopAll = true;
        while(avancement < 1)
        {
            transform.position += direcfion;
            yield return new WaitForSeconds(0.05f);
            if(X == true)
                avancement += Math.Abs(direcfion.x);
            else
                avancement += Math.Abs(direcfion.y);
        }
        avancement = 0;
        player.stopAll = false;
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

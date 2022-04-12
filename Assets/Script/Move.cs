using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private Image up;
    [SerializeField] private Image down;
    [SerializeField] private Image left;
    [SerializeField] private Image right;
    public Animator walkn;
    public MovingHeart GetBool;
    public float avancement = 0;
    private bool X;


    void disapear()
    {
        up.enabled = false;
        down.enabled = false;
        left.enabled = false;
        right.enabled = false;
    }
    void Up()
    {
        if(player.stopUp == false && player.stopAll == false && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
            //transform.position += transform.up * player.speed *Time.deltaTime;
            disapear();
            player.stopAll = true;
            X = false;
            StartCoroutine(str8movin(new Vector3(0,0.1f,0)));
            walkn.Play("Haut");
        }
    }
    void Down()
    {
        if(player.stopDown == false && player.stopAll == false && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)){
            //transform.position -= transform.up * player.speed *Time.deltaTime;
            disapear();
            player.stopAll = true;
            X = false;
            StartCoroutine(str8movin(new Vector3(0,-0.1f,0)));
            walkn.Play("Bas");
        }
    }
    void Left()
    {
        if(player.stopLeft == false && player.stopAll == false){
            //transform.position -= transform.right * player.speed *Time.deltaTime;
            disapear();
            player.stopAll = true;
            X = true;
            StartCoroutine(str8movin(new Vector3(-0.1f,0,0)));
            walkn.Play("Gauche");
        }
    }
    void Right()
    {
        if(player.stopRight == false && player.stopAll == false){
            //transform.position += transform.right * player.speed *Time.deltaTime;
            disapear();
            player.stopAll = true;
            X = true;
            StartCoroutine(str8movin(new Vector3(0.1f,0,0)));
            walkn.Play("Droit");
        }
    }
    public IEnumerator wait()
    {
        avancement = 0;
        yield return new WaitForSeconds(0.6f);
        player.stopAll = false;
    }
    private IEnumerator str8movin(Vector3 direcfion)
    {
        while(avancement < 1)
        {
            transform.position += direcfion;
            yield return new WaitForSeconds(0.05f);
            if(X == true)
                avancement += Math.Abs(direcfion.x);
            else
                avancement += Math.Abs(direcfion.y);
        }
        StartCoroutine(wait());
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
        if(player.stopAll == false)
        {
            if(player.stopUp == false)
                up.enabled = true;
            if(player.stopDown == false)
                down.enabled = true;
            if(player.stopLeft == false)
                left.enabled = true;
            if(player.stopRight == false)
                right.enabled = true;
        }
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

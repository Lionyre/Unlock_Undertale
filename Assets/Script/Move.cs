using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Player player = null;
    public Animator walkn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(player.stopUp == false && player.stopAll == false){
                transform.position += transform.up * player.speed *Time.deltaTime;
            }
            if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                walkn.Play("up");
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(player.stopDown == false && player.stopAll == false){
                transform.position -= transform.up * player.speed *Time.deltaTime;
            }
            if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                    walkn.Play("down");
            }
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(player.stopRight == false && player.stopAll == false){
                transform.position += transform.right * player.speed *Time.deltaTime;
            }
            walkn.Play("right");
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(player.stopLeft == false && player.stopAll == false){
                transform.position -= transform.right * player.speed *Time.deltaTime;
            }
            walkn.Play("left");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Player player = null;
    private Vector3 str8Movin;
    private float speed = 3;
    public Animator walkn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            if(player.stopUp == false){
                transform.position += transform.up * speed *Time.deltaTime;
            }
            if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                walkn.Play("up");
            }
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(player.stopDown == false){
                transform.position -= transform.up * speed *Time.deltaTime;
            }
            if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
            {
                    walkn.Play("down");
            }
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(player.stopRight == false){
                transform.position += transform.right * speed *Time.deltaTime;
            }
            walkn.Play("right");
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(player.stopLeft == false){
                transform.position -= transform.right * speed *Time.deltaTime;
            }
            walkn.Play("left");
        }
    }
}
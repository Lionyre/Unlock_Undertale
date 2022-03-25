using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPMove : MonoBehaviour
{
    Vector2 _movementX;
    Vector2 _movementY;
    private float _speed;
    [SerializeField] private Rigidbody2D _rb;

    void Update()
    {


        MovePlayer();



    }

    private void MovePlayer()
    {
        /*float h = Input.GetAxis("Horizontal") * _speed;*/

      
        float h = Input.GetAxis("Horizontal") * _speed;
        _rb.velocity = new Vector2(h , _rb.velocity.x);


        float v = Input.GetAxis("Vertical") * _speed;
        _rb.velocity = new Vector2(v, _rb.velocity.y);


        Debug.Log("Player OK");

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPMove : MonoBehaviour
{
    public float _speed;
    [SerializeField] private Rigidbody2D _rb;
    public MovingHeart GetBool;

    public ChangeForm[] _changeForms;
    //public ChangeForm1[] _changeForms1;

    public  Vector2 _movement;
    public  Vector2 _currentMovement;

    public bool _canMove;

    private void Start()
    {
        _changeForms = GameObject.FindObjectsOfType<ChangeForm>();
        //_changeForms1 = GameObject.FindObjectsOfType<ChangeForm1>();

        _speed = _speed * Time.deltaTime;



    }

    void Update()
    {
        StayGlace();

    }

    public void StayGlace()
    {
        _rb.velocity = _currentMovement;

        if (_canMove)
        {
            _currentMovement = _movement;
            MovePlayer();
            Deplacement();
        }
    }

    public void Deplacement()
    {
        if (GetBool.IsOnClickUp == true)
        {
            _movement.y = _speed;
            Debug.LogWarning("UP");
        }
        else if (GetBool.IsOnClickDown == true)
        {
            _movement.y = -_speed;
        }
        else if (GetBool.IsOnClickLeft == true)
        {
            _movement.x = - _speed;
        }
        else if (GetBool.IsOnClickRight == true)
        {
            _movement.x = _speed;
        }
        else
        {
            _movement = new Vector2 (0, 0);
        }

        
    }

    public void MovePlayer()
    {
        //_movement.x = Input.GetAxisRaw("Horizontal") * _speed;
        //_movement.y = Input.GetAxisRaw("Vertical") * _speed;

        if (_movement.x != 0)
        {
            _movement.y = 0;
        }

        if (_movement.y != 0)
        {
            _movement.x = 0;
        }

        
    }
}

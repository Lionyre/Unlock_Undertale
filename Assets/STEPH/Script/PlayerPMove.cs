using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPMove : MonoBehaviour
{
    public float _speed;
    [SerializeField] private Rigidbody2D _rb;

    public ChangeForm[] _changeForms;

    public  Vector2 _movement;
    public  Vector2 _currentMovement;

    public bool _canMove;

    private void Start()
    {
        _changeForms = GameObject.FindObjectsOfType<ChangeForm>();

        
    }

    void Update()
    {
        _rb.velocity = _currentMovement;

        if(_canMove)
        {
            _currentMovement = _movement;
            MovePlayer();
        }

    }

    private void MovePlayer()
    {
        _movement.x = Input.GetAxisRaw("Horizontal") * _speed;
        _movement.y = Input.GetAxisRaw("Vertical") * _speed;
    }
}

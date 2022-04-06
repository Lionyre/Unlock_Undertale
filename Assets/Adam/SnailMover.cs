using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMover : MonoBehaviour
{

    [SerializeField] AdamMove _adamMove;
    [SerializeField] Animator _animator;

    private float _speed;
    public float _minSpeed = 0.4f;
    public float _maxSpeed = 0.7f;

    private void Start()
    {
        StartCoroutine(SpeedChange());
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(2 * _speed / 100, 0, 0);
    }

    IEnumerator SpeedChange()
    {
        if(_adamMove._isStarted == true && _adamMove._canClick == true)
        {
            _speed = Random.Range(_minSpeed, _maxSpeed);
            _animator.SetBool("Start", true);

            _animator.speed = 1 + _speed / 10;

            yield return new WaitForSeconds(Random.Range(0, 10));
        }

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(SpeedChange());
    }
}

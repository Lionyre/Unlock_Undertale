using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSwipe : MonoBehaviour
{
	public bool StopRotate;
	private Animator _animator;
	private bool AnimationIsFinish;
	private bool moving = true;
	private bool isRight;
	private float speed = 0.2f;
	
	private AudioSource throwSound;
	
	void Awake()
	{
		throwSound = GetComponent<AudioSource>();
		_animator = this.gameObject.GetComponent<Animator>();
		StartCoroutine(CouroutineLance());
		
		if(transform.position.x > 0)
		{
			isRight = true;
		}
		
		Destroy(gameObject, 6);
    }
	
	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.L))
		{
			StopRotate = true;
		}
		if(StopRotate == false && AnimationIsFinish == true)
		{
			RotateTowards(transform.position - Vector3.up);
		}
		else if(StopRotate == true && moving == true)
		{
			if(isRight)
			{
				transform.position -= transform.right * speed;
			}
			else
			{
				transform.position -= transform.right * -speed;
			}
			
			speed -= 0.0045f;
		}
	}
	
	private void RotateTowards(Vector2 target)
	{        
		Vector2 direction = (target - (Vector2)transform.position).normalized;
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
		var offset = 90f;
		transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
	}
	
	IEnumerator CouroutineLance()
	{
		yield return new WaitForSeconds(1);
		_animator.enabled = false;
		AnimationIsFinish = true;
		yield return new WaitForSeconds(0.5f);
		StopRotate = true;
		throwSound.Play();
	}
}

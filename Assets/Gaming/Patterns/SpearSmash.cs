using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSmash : MonoBehaviour
{
	private GameObject TargetPlayer;
	public bool StopRotate;
	private Animator _animator;
	private bool AnimationIsFinish;
	private bool moving = true;
	
	private Collider2D boxBottom;
	public GameObject spark;
	
	void Awake()
	{
		TargetPlayer = GameObject.Find("Coeur");
		_animator = this.gameObject.GetComponent<Animator>();
		StartCoroutine(CouroutineLance());
		boxBottom = GameObject.Find("BottomSide").GetComponent<Collider2D>();
    }
	
	void FixedUpdate()
	{
		if(Input.GetKeyDown(KeyCode.L))
		{
			StopRotate = true;
		}
		if(StopRotate == false && AnimationIsFinish == true)
		{
			RotateTowards(transform.position - transform.up);
		}
		else if(StopRotate == true && moving == true)
		{
			transform.position -= transform.up * 0.2f;
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
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other == boxBottom)
		{
			moving = false;
			
			int sparkCount = Random.Range(3, 8);
			while(sparkCount >= 1)
			{
				Instantiate(spark, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
				sparkCount--;
			}
			
			GetComponent<Collider2D>().enabled = false;
			//animator.Play(disaspear_ptdr);
			Destroy(gameObject, 3);
		}
	}
}

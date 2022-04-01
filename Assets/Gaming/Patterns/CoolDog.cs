using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDog : MonoBehaviour
{
	private GameObject player;
	
	void Start()
	{
		player = GameObject.Find("Coeur");
		RotateTowards(player.transform.position);
	}
	
	void Update()
	{
		transform.position -= transform.up * 0.15f;
	}
	
	private void RotateTowards(Vector2 target)
	{        
		Vector2 direction = (target - (Vector2)transform.position).normalized;
		var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
		var offset = 90f;
		transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
	}
}

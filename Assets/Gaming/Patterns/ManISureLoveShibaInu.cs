using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManISureLoveShibaInu : MonoBehaviour
{
	private Transform player;
	private Vector3 dir;
	
	void Awake()
	{
		player = GameObject.Find("Coeur").transform;
		dir = player.position - transform.position;
	}
	
	void Update()
	{
		transform.position += dir.normalized * 0.02f;
	}
}

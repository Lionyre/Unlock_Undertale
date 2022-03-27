using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouhouMasterSpark : MonoBehaviour
{
	void Awake()
	{
		GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(0.1f, 1f), Random.Range(1f, 3f), 0));
	}
}

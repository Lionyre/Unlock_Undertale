using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouhouMasterSpark : MonoBehaviour
{
	void Awake()
	{
		GetComponent<Rigidbody2D>().AddForce(new Vector3(Random.Range(-100f, 100f), Random.Range(150f, 330f), 0));
		Destroy(gameObject, 6);
	}
}

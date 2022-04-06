using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePatterns : MonoBehaviour
{
	public GameObject soul;
	
	public GameObject spearSwipe;
	public GameObject spearSpin;
	public GameObject spearSmash;
	public GameObject dog;
	public GameObject bark;
	
	private int pattern;
	private int lastPattern;
	private int barksLeft;
	private float timerSpawn;
	private bool spawnedDog;
	
	void OnEnable()
	{
		while(pattern == lastPattern)
		{
			pattern = Random.Range(0, 3);
		}
		
		lastPattern = pattern;
		
		barksLeft = 0;
		spawnedDog = false;
		soul.transform.position = new Vector3(0f, -1.48f, 0f);
	}
	
	void OnDisable()
	{
		GameObject[] bullets = GameObject.FindGameObjectsWithTag("Danger");
		foreach(GameObject bullet in bullets)
		{
			Destroy(bullet);
		}
	}
	
	void Update()
	{
		timerSpawn -= Time.deltaTime;
		
		if(timerSpawn <= 0 && soul.GetComponent<Health>().CurrentHealth > 0)
		{	
			if(pattern == 1)
			{
				StartCoroutine(SpearSwipes());
			}
			else if(pattern == 2)
			{
				SpearSmash();
			}
			else
			{
				Dog();
			}
		}
	}
	
	IEnumerator SpearSwipes()
	{
		timerSpawn = 10f;
		Instantiate(spearSwipe, new Vector3(4f, -1f, 0f), Quaternion.identity);
		yield return new WaitForSeconds(3f);
		Instantiate(spearSwipe, new Vector3(-4f, -1f, 0f), Quaternion.identity);
		yield return new WaitForSeconds(3f);
		Instantiate(spearSpin, new Vector3(4f, -1f, 0f), Quaternion.identity);
	}
	
	void SpearSmash()
	{
		timerSpawn = 2.5f;
		Instantiate(spearSmash, new Vector3(Random.Range(-1.33f, 1.33f), 2.5f, 0f), Quaternion.identity);
	}
	
	void Dog()
	{
		if(spawnedDog)
		{
			timerSpawn = 0.4f;
			
			if(barksLeft <= 0)
			{
				barksLeft = Random.Range(1, 5);
			}
			else
			{
				barksLeft--;
				Instantiate(bark, new Vector3(0f, -2.3f, 0f), Quaternion.identity);
			}
		}
		else
		{	
			spawnedDog = true;
			GameObject doggo = Instantiate(dog, new Vector3(0f, -2.3f, 0f), Quaternion.identity);
			Destroy(doggo, 10);
		}
	}
}

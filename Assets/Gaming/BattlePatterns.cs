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
	
	private int pattern;
	private int lastPattern;
	private float timerSpawn;
	
	void OnEnabled()
	{
		while(pattern == lastPattern)
		{
			pattern = Random.Range(0, 3);
		}
		
		lastPattern = pattern;
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
				StartCoroutine(Dog());
			}
		}
	}
	
	
	
	
	
	IEnumerator SpearSwipes()
	{
		//spear swipes most of the attack box from an horizontal direction, then another in the other
		
		yield return new WaitForSeconds(0.01f);
		SpearSmash();
	}
	
	void SpearSmash()
	{
		timerSpawn = 3f;
		Instantiate(spearSmash, new Vector3(Random.Range(-1.33f, 1.33f), 2.5f, 0f), Quaternion.identity);
	}
	
	IEnumerator Dog()
	{
		//dog barks at you
		
		yield return new WaitForSeconds(0.01f);
		SpearSmash();
	}
}

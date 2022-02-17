using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePatterns : MonoBehaviour
{
	public GameObject soul;
	
	private int pattern;
	private int lastPattern;
	
	void OnEnabled()
	{
		while(pattern == lastPattern)
		{
			pattern = Random.Range(0, 3);
		}
		
		lastPattern = pattern;
		
		switch(pattern)
		{
		case 0:
			SpearSwipes();
			break;
		case 1:
			SpearSmash();
			break;
		case 2:
			Dog();
			break;
		}
	}
	
	void SpearSwipes()
	{
		//spear swipes most of the attack box from an horizontal direction, then another in the other
	}
	
	void SpearSmash()
	{
		//spear comes down towards soul until it hits the bottom of the box, stops and creates some spark projectiles
	}
	
	void Dog()
	{
		//dog barks at you
	}
}

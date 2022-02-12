using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
	public int maxHealth;
	public int currentHealth;
	public Slider slider;
	public TMP_Text damageDealtText;
	public Animator textAnimator;
	public Animator enemyAnimator;
	public BattleMenu battleMenu;
	
	public float baseDamage;
	public float baseDamageDecay;
	public float sliderAnimDuration;
	
	void Start()
	{
		currentHealth = maxHealth;
		slider.maxValue = maxHealth;
		slider.value = maxHealth;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			StartCoroutine(TakeDamage(1));
		}
		else if(Input.GetKeyDown(KeyCode.N))
		{
			StartCoroutine(TakeDamage(0.8f));
		}
		else if(Input.GetKeyDown(KeyCode.M))
		{
			StartCoroutine(TakeDamage(0.2f));
		}
	}
	
	public IEnumerator TakeDamage(float hitAccuracy)
	{
		yield return new WaitForSeconds(0.5f);
		
		float variance = Random.Range(0.9f, 1.1f);
		float damageTakenF = baseDamage * variance * hitAccuracy;
		int damageTaken = (int) damageTakenF;
		
		baseDamage = baseDamage * baseDamageDecay;
		baseDamageDecay *= baseDamageDecay;
		
		currentHealth -= damageTaken;
		
		damageDealtText.text = damageTaken.ToString();
		slider.gameObject.SetActive(true);
		
		textAnimator.Play("text_hit");
		enemyAnimator.Play("hit");
		
		float time = 0;
		
		while(time < sliderAnimDuration)
		{
			time += Time.deltaTime;
			slider.value = currentHealth + damageTaken * (1 - (time / sliderAnimDuration));
			yield return new WaitForSeconds(0.01f);
		}
		
		slider.value = currentHealth;
		
		yield return new WaitForSeconds(1f);
		slider.gameObject.SetActive(false);
		
		if(currentHealth <= 0)
		{
			enemyAnimator.Play("story_of_undertale");
			battleMenu.Win(true);
		}
		else
		{
			battleMenu.EnemyTurn();
		}
	}
}

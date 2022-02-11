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
	
	public float baseDamage;
	public float baseDamageDecay;
	public float sliderAnimSpeed;
	
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
			StartCoroutine(TakeDamage());
		}
	}
	
	IEnumerator TakeDamage()
	{
		float variance = Random.Range(0.85f, 1.15f);
		float damageTakenF = baseDamage * variance;
		int damageTaken = (int) damageTakenF;
		
		baseDamage = baseDamage * baseDamageDecay;
		
		int oldHealth = currentHealth;
		currentHealth -= damageTaken;
		
		damageDealtText.text = damageTaken.ToString();
		slider.gameObject.SetActive(true);
		
		textAnimator.Play("text_hit");
		enemyAnimator.Play("hit");
		
		while(slider.value > currentHealth || slider.value <= 0)
		{
			slider.value -= Time.deltaTime * sliderAnimSpeed;
			yield return new WaitForSeconds(0.01f);
		}
		
		slider.value = currentHealth;
		
		yield return new WaitForSeconds(1f);
		slider.gameObject.SetActive(false);
		
		if(currentHealth <= 0)
		{
			Genocided();
		}
	}
	
	void Genocided()
	{
		enemyAnimator.Play("story_of_undertale");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitByGaming : MonoBehaviour
{
    [SerializeField] private Health healthPlayer;
    private bool isHit;
	private Animator animator;
	private AudioSource hurtSound;
	
	void Awake()
	{
		animator = gameObject.GetComponent<Animator>();
		hurtSound = GetComponent<AudioSource>();
	}
	
	void OnDisable()
	{
		StopAllCoroutines();
		isHit = false;
		animator.Play("Idle");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.gameObject.tag == "Danger" && !isHit)
        {
			healthPlayer.CurrentHealth -= 5;
			hurtSound.Play();
			StartCoroutine(CoolDownHit());
        }
    }

    IEnumerator CoolDownHit()
    {
        isHit = true;
		animator.Play("hurt");
        yield return new WaitForSeconds(1.5f);
        isHit = false;
		animator.Play("Idle");
    }
}

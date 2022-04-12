using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpearTowards : MonoBehaviour
{
    private GameObject TargetPlayer;
    public bool StopRotate;
    private Animator _animator;
    private bool AnimationIsFinish;
	
	private AudioSource launchSound;
    
    private void Awake() {
        TargetPlayer = GameObject.Find("Coeur");
        _animator = this.gameObject.GetComponent<Animator>();
        StartCoroutine(CouroutineLance());
        Destroy(this.gameObject, 20);
		
		launchSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            StopRotate = true;
        }
        if(StopRotate == false && AnimationIsFinish == true)
        {
            RotateTowards( TargetPlayer.transform.position);
        }
        else if(StopRotate == true)
        {
            transform.position -= transform.up * 0.2f;
        }
    }

    private void RotateTowards(Vector2 target)
 {        
     Vector2 direction = (target - (Vector2)transform.position).normalized;
     var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
     var offset = 90f;
     transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
 }

    IEnumerator CouroutineLance()
    {
        yield return new WaitForSeconds(1);
        _animator.enabled = false;
        AnimationIsFinish = true;
        yield return new WaitForSeconds(0.5f);
		launchSound.Play();
        StopRotate = true;
    }
}

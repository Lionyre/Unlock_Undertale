using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitByItem : MonoBehaviour
{
    [SerializeField] private Health HealthPlayer;
    private bool IsHit;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Danger")
        {
            if(IsHit == false)
            {
                HealthPlayer.CurrentHealth -= 5;
            }
            StartCoroutine(CoolDownHit());
        }
    }

    IEnumerator CoolDownHit()
    {
        IsHit = true;
        yield return new WaitForSeconds(0.5f);
        IsHit = false;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitByItem : MonoBehaviour
{
    [SerializeField] private Health HealthPlayer;
    private bool IsHit;
    public Color ColorImage;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Danger")
        {
            if(IsHit == false)
            {
                HealthPlayer.CurrentHealth -= 5;
            }
            StartCoroutine(CoolDownHit());
        }
        else if(other.gameObject.tag == "LanceMur")
        {
            HealthPlayer.CurrentHealth = 0;
        }
    }

    IEnumerator CoolDownHit()
    {
        IsHit = true;
        yield return new WaitForSeconds(0.1f);
        ColorImage.a = 0f;
        yield return new WaitForSeconds(0.1f);
        ColorImage.a = 1f;
        yield return new WaitForSeconds(0.1f);
        ColorImage.a = 0f;
        yield return new WaitForSeconds(0.1f);
        ColorImage.a = 1f;
        yield return new WaitForSeconds(0.1f);
        IsHit = false;
        
    }

    private void Update() {
        gameObject.GetComponent<SpriteRenderer>().color = ColorImage;
    }
}

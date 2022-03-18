using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitByItem : MonoBehaviour
{
    [SerializeField] private Health HealthPlayer;
    private bool IsHit;
    public Color ColorImage;
    private bool Clignotte;


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
        yield return new WaitForSeconds(1.5f);
        IsHit = false;
        
    }

    private void Update() 
    {
        gameObject.GetComponent<SpriteRenderer>().color = ColorImage;
        ClignoteStp();
    }

    private void Start() {
        StartCoroutine(TempsClignotement());
    }

    private void ClignoteStp()
    {
        if(IsHit == true && Clignotte == false)
        {
            ColorImage.a = 1f;
        }
        else if(IsHit == true && Clignotte == true)
        {
            ColorImage.a = 0f;
        }
        else if(IsHit == false)
        {
            ColorImage.a = 1f;
        }
        
    }

    IEnumerator TempsClignotement()
    {
        while(true)
        {
            Clignotte = false;
            yield return new WaitForSeconds(0.1f);
            Clignotte = true;
            yield return new WaitForSeconds(0.1f);
        }
    }

}

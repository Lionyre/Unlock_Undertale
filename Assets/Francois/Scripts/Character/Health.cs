using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    public int CurrentHealth;
    public Slider LifeSlider;
    public TMP_Text ValeurVie;
    [SerializeField] private GameObject AnnonceMort;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        GetSliderValue();
        GetValueLife();
        ReloadTheScene();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CurrentHealth -= 10;
        }
    }

    void GetSliderValue()
    {
        LifeSlider.maxValue = MaxHealth;
        LifeSlider.value = CurrentHealth;
    }

    void GetValueLife()
    {
        ValeurVie.text = CurrentHealth.ToString("00/") + MaxHealth.ToString("00");
    }

    void ReloadTheScene()
    {
        if(CurrentHealth <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine("YouDead");
        }
    }

    IEnumerator YouDead()
    {
        AnnonceMort.SetActive(true);
        yield return new WaitForSeconds(5);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}

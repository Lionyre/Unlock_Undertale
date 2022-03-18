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
	
	public bool usedDT = false;

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
			if(usedDT)
			{
				Scene scene = SceneManager.GetActiveScene(); 
				SceneManager.LoadScene(scene.name);
			}
			else
			{
				CurrentHealth = 1;
				usedDT = true;
			}
        }
    }

    IEnumerator YouDead()
    {
        //AnnonceMort.SetActive(true);
        yield return new WaitForSeconds(5);
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}

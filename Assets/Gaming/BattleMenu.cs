using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleMenu : MonoBehaviour
{
	public Button fightButton;
	public Button itemButton;
	public Button mercyButton;
	
	public Button attackButton;
	public Button itemCancelButton;
	public Button spareButton;
	public Button fleeButton;
	public Button mercyCancelButton;
	public Button returnButton;
	
	public GameObject mainMenu;
	public GameObject fightMenu;
	public GameObject itemMenu;
	public GameObject mercyMenu;
	public GameObject battleMenu;
	public GameObject wonMenu;
	
	public GameObject textBox;
	public GameObject battleBox;
	
	public Slider attackSlider;
	public TMP_InputField itemInput;
	public TMP_Text itemUseText;
	public TMP_Text spareText;
	public TMP_Text wonText;
	public EnemyHealth enemyHealth;
	
	private bool canBeSpared;
	private bool isAttacking;
	public float barSpeed;
	public Animator handle;
	
	void Start()
	{
		fightButton.onClick.AddListener(Fight);
		itemButton.onClick.AddListener(Item);
		mercyButton.onClick.AddListener(Mercy);
		
		attackButton.onClick.AddListener(FightAttack);
		spareButton.onClick.AddListener(Spare);
		fleeButton.onClick.AddListener(Quit);
		mercyCancelButton.onClick.AddListener(Cancel);
		itemCancelButton.onClick.AddListener(Cancel);
		returnButton.onClick.AddListener(Quit);
		
		itemInput.onEndEdit.AddListener(delegate {UseItem(); });
	}
	
	void Update()
	{
		if(isAttacking)
		{
			if(attackSlider.value < 1)
			{
				attackSlider.value += Time.deltaTime * barSpeed;
			}
			else
			{
				attackButton.enabled = false;
				isAttacking = false;
				EnemyTurn();
			}
		}
	}
	
	void Fight()
	{
		mainMenu.SetActive(false);
		fightMenu.SetActive(true);
		attackButton.enabled = true;
		isAttacking = true;
		attackSlider.value = 0;
		handle.Play("normal");
	}
	
	void FightAttack()
	{
		attackButton.enabled = false;
		isAttacking = false;
		
		float hitAccuracy = 0;
		
		Debug.Log(attackSlider.value);
		
		if(attackSlider.value < 0.48f)
		{
			hitAccuracy = attackSlider.value * 1.8f + 0.1f;
		}
		else if(attackSlider.value >= 0.48f && attackSlider.value <= 0.52f)
		{
			hitAccuracy = 1.2f;
			Debug.Log("critical hit");
		}
		else
		{
			hitAccuracy = 1.1f - ((attackSlider.value - 0.5f) * 1.8f + 0.1f);
		}
		
		handle.Play("flashing");
		StartCoroutine(enemyHealth.TakeDamage(hitAccuracy));
	}
	
	public void EnemyTurn()
	{
		textBox.SetActive(false);
		battleBox.SetActive(true);
		fightMenu.SetActive(false);
		mercyMenu.SetActive(false);
		battleMenu.SetActive(true);
		
		StartCoroutine(ObjectiveSurvive());
	}
	
	IEnumerator ObjectiveSurvive()
	{
		yield return new WaitForSeconds(10f);
		
		battleBox.SetActive(false);
		textBox.SetActive(true);
		battleMenu.SetActive(false);
		mainMenu.SetActive(true);
	}
	
	void Item()
	{
		mainMenu.SetActive(false);
		itemMenu.SetActive(true);
	}
	
	void UseItem()
	{
		StartCoroutine(UseItemC());
	}
	
	IEnumerator UseItemC()
	{
		itemMenu.SetActive(false);
		itemUseText.gameObject.SetActive(true);
		
		if(itemInput.text == "63") // 11?
		{
			itemUseText.text = "* You throw the spaghetti stick at Greater Dog.\n* It looks content and can be SPARED.";
			canBeSpared = true;
		}
		else
		{
			itemUseText.text = "* Incorrect code.";
		}
		
		yield return new WaitForSeconds(5f);
		itemUseText.gameObject.SetActive(false);
		EnemyTurn();
	}
	
	void Mercy()
	{
		mainMenu.SetActive(false);
		mercyMenu.SetActive(true);
		
		if(canBeSpared)
		{
			spareText.color = Color.yellow;
		}
	}
	
	void Spare()
	{
		if(canBeSpared)
		{
			Win(false);
		}
		else
		{
			Debug.Log("can't spare rip bozo");
			//uh oh
			EnemyTurn();
		}
	}
	
	public void Win(bool genocide)
	{
		fightMenu.SetActive(false);
		mercyMenu.SetActive(false);
		wonMenu.SetActive(true);
		
		if(genocide)
		{
			wonText.text = "* You won!\n* You earned 80 EXP and 0 gold.";
		}
		else
		{
			wonText.text = "* You won!\n* You earned 0 EXP and 0 gold.";
		}
	}
	
	void Cancel()
	{
		itemMenu.SetActive(false);
		mercyMenu.SetActive(false);
		mainMenu.SetActive(true);
	}
	
	void Quit()
	{
		Debug.Log("fleeing...");
		//go back to main menu
	}
}

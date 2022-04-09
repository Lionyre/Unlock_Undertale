using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
	public Canvas battleMenu;
	public GameObject wonMenu;
	
	public GameObject textBox;
	public GameObject battleBox;
	
	public Slider attackSlider;
	public TMP_InputField itemInput;
	public TMP_Text text;
	public TMP_Text spareText;
	public EnemyHealth enemyHealth;
	
	private bool canBeSpared;
	private bool isAttacking;
	public float barSpeed;
	public Animator handle;
	
	private EnterMachine enterMachine;
	
	private AudioSource music;
	private AudioSource selectAudio;
	private AudioSource unselectAudio;
	private AudioSource fightAudio;
	private AudioSource fleeAudio;
	private AudioSource winAudio;
	
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
		
		//enterMachine = GameObject.Find("EnterMachine").GetComponent<EnterMachine>();
		
		music = GetComponent<AudioSource>();
		selectAudio = transform.GetChild(0).GetComponent<AudioSource>();
		unselectAudio = transform.GetChild(1).GetComponent<AudioSource>();
		fightAudio = transform.GetChild(2).GetComponent<AudioSource>();
		fleeAudio = transform.GetChild(3).GetComponent<AudioSource>();
		winAudio = transform.GetChild(4).GetComponent<AudioSource>();
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
		selectAudio.Play();
		
		mainMenu.SetActive(false);
		fightMenu.SetActive(true);
		attackButton.enabled = true;
		isAttacking = true;
		attackSlider.value = 0;
		handle.Play("normal");
	}
	
	void FightAttack()
	{
		fightAudio.Play();
		
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
		battleMenu.enabled = true;
		
		enemyHealth.enemyAnimator.Play("idle_battle");
		
		StartCoroutine(ObjectiveSurvive());
	}
	
	IEnumerator ObjectiveSurvive()
	{
		yield return new WaitForSeconds(10f);
		
		enemyHealth.enemyAnimator.Play("idle");
		
		battleBox.SetActive(false);
		textBox.SetActive(true);
		battleMenu.enabled = false;
		mainMenu.SetActive(true);
		StopAllCoroutines();
	}
	
	void Item()
	{
		selectAudio.Play();
		
		mainMenu.SetActive(false);
		itemMenu.SetActive(true);
	}
	
	void UseItem()
	{
		selectAudio.Play();
		
		StartCoroutine(UseItemC());
	}
	
	IEnumerator UseItemC()
	{
		itemMenu.SetActive(false);
		text.enabled = true;
		
		if(itemInput.text == "63")
		{
			text.text = "* You throw the spaghetti stick at Greater Dog./\n* It looks content and can be SPARED.";
			canBeSpared = true;
			text.gameObject.GetComponent<DialogueScriptEpico>().Awakent();
			
			Debug.Log(text);
			Debug.Log(text.gameObject);
			Debug.Log(text.gameObject.GetComponent<DialogueScriptEpico>());
			
			yield return new WaitForSeconds(5f);
		}
		else
		{
			text.text = "* Incorrect code.";
			text.gameObject.GetComponent<DialogueScriptEpico>().Awakent();
			
			yield return new WaitForSeconds(3f);
		}
		
		text.enabled = false;
		EnemyTurn();
	}
	
	void Mercy()
	{
		selectAudio.Play();
		
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
		winAudio.Play();
		music.Stop();
		
		fightMenu.SetActive(false);
		mercyMenu.SetActive(false);
		wonMenu.SetActive(true);
		text.enabled = true;
		
		if(genocide)
		{
			text.text = "* You won!/\n* You earned 80 EXP and 0 gold.";
		}
		else
		{
			text.text = "* You won!/\n* You earned 0 EXP and 0 gold.";
		}
		
		text.gameObject.GetComponent<DialogueScriptEpico>().useFinSound = true;
		text.gameObject.GetComponent<DialogueScriptEpico>().Awakent();
		
		enterMachine.finished[enterMachine.selection] = true;
		enterMachine.Victiore.SetActive(true); 
		SceneManager.UnloadSceneAsync("Gaming");
		GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = true;
	}
	
	void Cancel()
	{
		unselectAudio.Play();
		
		itemMenu.SetActive(false);
		mercyMenu.SetActive(false);
		mainMenu.SetActive(true);
	}
	
	void Quit()
	{
		fleeAudio.Play();
		
		Debug.Log("fleeing...");
		//go back to main menu
	}
}

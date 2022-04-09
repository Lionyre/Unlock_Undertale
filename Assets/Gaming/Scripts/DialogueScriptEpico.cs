using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScriptEpico : MonoBehaviour
{
    private TMP_Text dialogueText;
    public float typingSpeed;
	public bool useFinSound = false;
	private AudioSource typingSound;
	private AudioSource finTypingSound;
	
	void Awake()
	{
		typingSound = GetComponent<AudioSource>();
		finTypingSound = transform.GetChild(0).GetComponent<AudioSource>();
	}

    public void Awakent()
	{
        dialogueText = this.gameObject.GetComponent<TMP_Text>();
        StartCoroutine(TypeDialogue(dialogueText.text.ToString()));
    }

    IEnumerator TypeDialogue(string dialogueLine)
    {
		dialogueText.text = null;
		
		foreach(char letter in dialogueLine.ToCharArray())
		{
			if(letter == '/')
			{
				yield return new WaitForSeconds((1 / typingSpeed) * 10);
			}
			else
			{
				if(letter != ' ')
				{
					if(!useFinSound)
					{
						typingSound.Play();
					}
					else
					{
						finTypingSound.Play();
					}
				}
				
				dialogueText.text += letter;
				yield return new WaitForSeconds(1 / typingSpeed);
			}
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    private TMP_Text dialogueText;
    public float typingDelay;
	
	private AudioSource typingSound;

    private void Awake() {
        dialogueText = this.gameObject.GetComponent<TMP_Text>();
		typingSound = GetComponent<AudioSource>();
        StartCoroutine(TypeDialogue(dialogueText.text.ToString()));
    }

    IEnumerator TypeDialogue(string dialogueLine)
    {
        dialogueText.text = null;

        foreach(char letter in dialogueLine.ToCharArray())
        {
            if(letter != ' ')
                {
                    typingSound.Play();
                }

                dialogueText.text += letter;
                yield return new WaitForSeconds(1 / typingDelay);
                typingSound.Stop();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnterMachine : MonoBehaviour
{
    [SerializeField] private GameObject _inputField;

    [SerializeField] private int _characterNumber = 0;

    [SerializeField] private int _inputFieldValue;

    [SerializeField] private int[] card;

    [SerializeField] private string[] scenes;
    [SerializeField] public bool[] finished;
    [SerializeField] private string[] winMomentos;
    [SerializeField] private GameObject _viewPad;

    public int selectedCard;
    public string selectedScene;
    public TMP_Text selectedMomentos;



    public void EnterValue(int number)
    {
        if(_characterNumber < 4)
        {
            _characterNumber += 1;
            _inputField.GetComponent<TMP_InputField>().text += "" + number;

            _inputFieldValue = int.Parse(_inputField.GetComponent<TMP_InputField>().text);
        }
    }

    public void DeleteText()
    {
        _inputField.GetComponent<TMP_InputField>().text = "";
        _characterNumber = 0;
    }

    public void SetValue()
    {

        for (int i = 0; i < card.Length; i++)
        {
            if (_inputFieldValue == card[i] && finished[i] == false)
            {
                selectedCard = card[i];
                selectedScene = scenes[i];
                selectedMomentos.text = winMomentos[i];
            }
        }

        if(selectedCard != 0)
        {
            SceneManager.LoadScene(selectedScene, LoadSceneMode.Additive);
            GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = false;
            _viewPad.SetActive(false);
        }
    }

    public void QuitPad()
    {
        _viewPad.SetActive(false);
    }
}

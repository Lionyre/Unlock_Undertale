using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterNumberForClue : MonoBehaviour
{

    [SerializeField] private GameObject _inputField;

    [SerializeField] private int _characterNumber = 0;

    [SerializeField] private int _inputFieldValue;

    [SerializeField] private Indice[] _clues;

    public void EnterValue(int number)
    {
        if(_characterNumber < 2)
        {
            _characterNumber += 1;
            _inputField.GetComponent<TMP_InputField>().text += "" + number;
        }
    }

    public void DeleteText()
    {
        _inputField.GetComponent<TMP_InputField>().text = "";
        _characterNumber = 0;
    }

    public void SetValue()
    {
        int cardExsite = 0;

        for (int i = 0; i < _clues.Length; i++)
        {
            Debug.Log(_inputFieldValue + " = " + _clues[i]._CardID + " ?");

            if (_inputFieldValue == _clues[i]._CardID)
            {
                cardExsite += 1;
            }
            else
            {
                cardExsite += 0;
            }
        }

        if (cardExsite == 1)
        {
            Debug.Log("Voici l'incide");
        }
        else if(cardExsite > 1)
        {
            Debug.Log("Deux indices ont la meme cardID");
        }
        else
        {
            Debug.Log("Cette carte n'existe pas, ou aucun indice n'a été trouvé");
        }
    }
}

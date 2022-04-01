using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterNumber : MonoBehaviour
{

    [SerializeField] private GameObject _inputField;

    [SerializeField] private int _characterNumber = 0;

    [SerializeField] private int _inputFieldValue;

    [SerializeField] private Indice[] _clues;

    [SerializeField] private GameObject _viewClues;
    [SerializeField] private GameObject _viewPad;

    public Indice selectedClue = null;



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

    public void SetValueForClue()
    {

        for (int i = 0; i < _clues.Length; i++)
        {
            if (_inputFieldValue == _clues[i]._CardID)
            {
                selectedClue = _clues[i];
            }
        }

        if(selectedClue != null)
        {
            _viewClues.SetActive(true);
            _viewPad.SetActive(false);
        }
    }

    public void QuitPad()
    {
        this.gameObject.SetActive(false);
    }


}

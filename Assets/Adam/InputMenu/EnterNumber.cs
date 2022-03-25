using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterNumber : MonoBehaviour
{

    [SerializeField] private GameObject _inputField;

    [SerializeField] private int _characterNumber = 0;

    public void EnterValue(int number)
    {
        if(_characterNumber < 4)
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



}

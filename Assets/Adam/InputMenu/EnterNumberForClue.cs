using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterNumberForClue : MonoBehaviour
{

    [SerializeField] private GameObject _inputField;

    [SerializeField] private int _characterNumber = 0;

    [SerializeField] private Indice[] _clues;
    private List<Indice> _clus;

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
        if(_characterNumber == 2)
        {
            int i = int.Parse(_inputField.GetComponent<TMP_InputField>().text);
            Debug.Log(i);
        }
        else
        {
            Debug.Log("Il vous manque des chiffre");
        }

        for(int i = 0; i < _clues.Length; i++)
        {
            
        }
    }



}

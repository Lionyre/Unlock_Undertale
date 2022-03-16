using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterNumber : MonoBehaviour
{

    [SerializeField] private GameObject _inputField;

    public void EnterValue(int number)
    {
        _inputField.GetComponent<TMP_InputField>().text += "" + number;
    }

    public void DeleteText()
    {
        _inputField.GetComponent<TMP_InputField>().text = "";
    }

}

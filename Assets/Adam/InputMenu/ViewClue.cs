using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewClue : MonoBehaviour
{
    [SerializeField] private EnterNumber _enterNumberScript;
    [SerializeField] private TMP_Text _text;


    private void Start()
    {
        _text.text = _enterNumberScript.selectedClue._FirstClue;
    }

    public void ShowFirstClue(GameObject text)
    {
        _text.text = "";
        _text.text = _enterNumberScript.selectedClue._FirstClue;
    }

    public void ShowSecondClue(GameObject text)
    {
        _text.text = "";
        _text.text = _enterNumberScript.selectedClue._SecondClue;
    }

    public void ShowThirdClue(GameObject text)
    {
        _text.text = "";
        _text.text = _enterNumberScript.selectedClue._ThirdClue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typing : MonoBehaviour
{
    private string number = "";
    public TMP_Text Input;

    public void Zero(){
        number += "0";
    }
    public void Un(){
        number += "1";
    }
    public void Deux(){
        number += "2";
    }
    public void Trois(){
        number += "3";
    }
    public void Quatre(){
        number += "4";
    }
    public void Cinq(){
        number += "5";
    }
    public void Six(){
        number += "6";
    }
    public void Sept(){
        number += "7";
    }
    public void Huit(){
        number += "8";
    }
    public void Neuf(){
        number += "9";
    }
    public void Back(){
        number = number.Substring(0, number.Length - 1);
    }
    public void C(){
        number = "";
    }
    private void Update() {
        Input.text = number;
    }
}

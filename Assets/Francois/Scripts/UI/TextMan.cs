using UnityEngine;
using System.Collections;

public class TextMan : MonoBehaviour
{
    public string stringToEdit = "Hello World";

    void OnGUI()
    {
        // Make a text field that modifies stringToEdit.
        stringToEdit = GUI.TextField(new Rect(200, 200, 200, 20), stringToEdit, 25);
    }
}

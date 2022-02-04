using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingHeart : MonoBehaviour
{
    private Button MoveUp;
    private Button MoveDown;
    private Button MoveLeft;
    private Button MoveRight;

    private bool IsOnClick;

    private void Start() {
        MoveUp = GameObject.Find("UpButton").GetComponent<Button>();
        MoveDown = GameObject.Find("DownButton").GetComponent<Button>();
        MoveLeft = GameObject.Find("LeftButton").GetComponent<Button>();
        MoveRight = GameObject.Find("RightButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsOnClick == true)
        {
            Debug.Log("JE CLIIIIIQUE");
        }
        else if(IsOnClick == false)
        {
            Debug.Log("fini");
        }
    }

    public void MouvementPerso()
    {
        Debug.Log("JE CLIIIIIQUE");
    }

    public void CheckIfDown()
    {
        IsOnClick = true;
    } 

    public void CheckIfClickUp()
    {
        IsOnClick = false;
    }
}

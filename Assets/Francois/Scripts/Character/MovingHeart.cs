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

    public bool IsOnClickUp;
    public bool IsOnClickDown;
    public bool IsOnClickLeft;
    public bool IsOnClickRight;

    private void Start() {
        MoveUp = GameObject.Find("UpButton").GetComponent<Button>();
        MoveDown = GameObject.Find("DownButton").GetComponent<Button>();
        MoveLeft = GameObject.Find("LeftButton").GetComponent<Button>();
        MoveRight = GameObject.Find("RightButton").GetComponent<Button>();
    }

    public void MouvementPerso()
    {
        Debug.Log("JE CLIIIIIQUE");
    }

    public void ClickUp()
    {
        IsOnClickUp = true;
    } 

    public void ReleaseUp()
    {
        IsOnClickUp = false;
    }

    public void ClickDown()
    {
        IsOnClickDown = true;
    } 

    public void ReleaseDown()
    {
        IsOnClickDown = false;
    }

    public void ClickRight()
    {
        IsOnClickRight = true;
    } 

    public void ReleaseRight()
    {
        IsOnClickRight = false;
    }

    public void ClickLeft()
    {
        IsOnClickLeft = true;
    } 

    public void ReleaseLeft()
    {
        IsOnClickLeft = false;
    }
}

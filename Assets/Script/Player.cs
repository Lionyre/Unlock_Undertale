using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject hitboxes = null;
    public float speed = 3;
    public bool orange = false;
    public bool stopUp = false;
    public bool stopDown = false;
    public bool stopLeft = false;
    public bool stopRight = false;
    public bool stopAll = false;
    public GameObject Hitboxes => hitboxes;
}

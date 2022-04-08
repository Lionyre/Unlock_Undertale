using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    public GameObject lemon;
    public GameObject effects;
    [SerializeField] private Player player = null;
    private EnterMachine Machine;

    private void Start() {
        Time.timeScale = 1;
    }
    private void Awake() 
    {
        Time.timeScale = 1;
        Machine = GameObject.Find("EnterMachine").GetComponent<EnterMachine>();
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.gameObject.layer == 0 && player.stopAll == false)
        {
            lemon.SetActive(false);
            effects.SetActive(false);
            player.stopAll = true;
            Machine.finished[Machine.selection] = true;
            Machine.Victiore.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{
    public GameObject lemon;
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
            player.stopAll = true;
            Machine.finished[Machine.selection] = true;
            Machine.Victiore.SetActive(true);
            SceneManager.UnloadSceneAsync("Dalles de couleurs");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinFactor : MonoBehaviour
{
    public GameObject FadeOut;
    public EnterMachine Machine;
    // Start is called before the first frame update
    private void Awake() {
        Machine = GameObject.Find("EnterMachine").GetComponent<EnterMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "WinFactor")
        {
            StartCoroutine(ChangeOfScene());
        }
    }

    IEnumerator ChangeOfScene()
    {
        Time.timeScale = 0;
        FadeOut.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1;
        GameObject.Find("CanvasMenu").GetComponent<Canvas>().enabled = true;
        Machine.finished[Machine.selection] = true;
        SceneManager.UnloadSceneAsync("FrancoisMinigame");
        //SceneManager.LoadScene("InterfaceFrancois");
    }
}

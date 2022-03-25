using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinFactor : MonoBehaviour
{
    public GameObject FadeOut;
    // Start is called before the first frame update
    void Start()
    {
        
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
        SceneManager.LoadScene("InterfaceFrancois");
    }
}

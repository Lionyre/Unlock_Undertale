using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    private bool disparition;
    private void Update() {
        if(disparition == false)
        {
            disparition = true;
            StartCoroutine(depop());
        }
    }
    private IEnumerator depop()
    {
        yield return new WaitForSeconds(0.5f);
        disparition = false;
        this.gameObject.SetActive(false);
    }
}

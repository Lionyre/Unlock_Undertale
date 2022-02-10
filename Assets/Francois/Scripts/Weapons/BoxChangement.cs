using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChangement : MonoBehaviour
{
    public GameObject PrefabSpear;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpearAndBox());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpearAndBox()
    {
        yield return new WaitForSeconds(30);
        Instantiate(PrefabSpear);
        yield return new WaitForSeconds(30);
        Destroy(this.gameObject);
    }
}
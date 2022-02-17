using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpear : MonoBehaviour
{
    public GameObject SpearPrefab;
    private float TimerSpawn = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerSpawn -= Time.fixedDeltaTime;
        if(TimerSpawn <= 0)
        {
            StartCoroutine("SpawnLance");
        }
    }

    IEnumerator SpawnLance()
    {
        TimerSpawn = 5f;
        Instantiate(SpearPrefab, new Vector3(Random.Range(-3.5f,3.5f), Random.Range(1.5f,3.85f), 0f), Quaternion.identity);
         yield return new WaitForSeconds(0.4f);
        Instantiate(SpearPrefab, new Vector3(Random.Range(-3.5f,3.5f), Random.Range(1.5f,3.85f), 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(SpearPrefab, new Vector3(Random.Range(-3.5f,3.5f), Random.Range(1.5f,3.85f), 0f), Quaternion.identity);
    }
}

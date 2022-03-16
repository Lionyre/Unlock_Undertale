using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSpear : MonoBehaviour
{
    public GameObject SpearPrefab;
    private float TimerSpawn = 5f;
    [SerializeField] private GameObject Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        TimerSpawn -= Time.fixedDeltaTime;
        if(TimerSpawn <= 0 && Player.GetComponent<Health>().CurrentHealth > 0)
        {
            StartCoroutine("SpawnLance");
        }
    }

    IEnumerator SpawnLance()
    {
        TimerSpawn = 5f;
        Instantiate(SpearPrefab, new Vector3(Random.Range(-3.5f,3.5f), Random.Range(1.5f,3.85f), 0f), Quaternion.identity);
         yield return new WaitForSeconds(0.6f);
        Instantiate(SpearPrefab, new Vector3(Random.Range(-3.5f,3.5f), Random.Range(1.5f,3.85f), 0f), Quaternion.identity);
        yield return new WaitForSeconds(0.6f);
        Instantiate(SpearPrefab, new Vector3(Random.Range(-3.5f,3.5f), Random.Range(1.5f,3.85f), 0f), Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHazard : MonoBehaviour
{
    [SerializeField] private Player player = null;
    public bool electrique = false;
    public GameObject repousse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == 0 && other.gameObject.name == "Player" && (player.orange == true || electrique == true))
        {
            player.stopAll = true;
            repousse.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

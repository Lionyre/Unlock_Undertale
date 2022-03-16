using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHazard : MonoBehaviour
{
    [SerializeField] private Player player = null;
    private Animator direction;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 0 && other.gameObject.name == "Player")
        {
            Debug.Log("oskour");
            direction = other.gameObject.GetComponent<Animator>();
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("up"))
            {
                player.transform.position -= transform.up * 2 * player.speed *Time.deltaTime;
            }
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("down"))
            {
                player.transform.position += transform.up * 2 * player.speed *Time.deltaTime;
            }
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("right"))
            {
                player.transform.position -= transform.right * 2 * player.speed *Time.deltaTime;
            }
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("left"))
            {
                player.transform.position += transform.right * 2 * player.speed *Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 0 && other.gameObject.name == "Player")
        {
            player.stopAll = false;
            this.gameObject.SetActive(false);
        }
    }
}

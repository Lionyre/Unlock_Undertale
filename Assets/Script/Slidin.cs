using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slidin : MonoBehaviour
{
    [SerializeField] private Player player = null;
    private Animator direction;

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.layer == 0 && other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<Move>().avancement -= 1;
            player.orange = false;
            // player.stopAll = true;
        }
    }
    // private void OnTriggerStay2D(Collider2D other) {
    //     if (other.gameObject.layer == 0 && other.gameObject.name == "Player")
    //     {
    //         direction = other.gameObject.GetComponent<Animator>();
    //         if(direction.GetCurrentAnimatorStateInfo(0).IsName("up"))
    //         {
    //             player.transform.position += transform.up * player.speed *Time.deltaTime;
    //         }
    //         if(direction.GetCurrentAnimatorStateInfo(0).IsName("down"))
    //         {
    //             player.transform.position -= transform.up * player.speed *Time.deltaTime;
    //         }
    //         if(direction.GetCurrentAnimatorStateInfo(0).IsName("right"))
    //         {
    //             player.transform.position += transform.right * player.speed *Time.deltaTime;
    //         }
    //         if(direction.GetCurrentAnimatorStateInfo(0).IsName("left"))
    //         {
    //             player.transform.position -= transform.right * player.speed *Time.deltaTime;
    //         }
    //     }
    // }
    // private void OnTriggerExit2D(Collider2D other) {
    //     if (other.gameObject.layer == 0 && other.gameObject.name == "Player")
    //     {
    //         player.stopAll = false;
    //     }
    // }
}

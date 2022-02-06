using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop : MonoBehaviour
{
    [SerializeField] private Player player = null;
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 4)
        {
            switch(name)
		    {
			    case "up":
                    player.stopUp = true;
                break;
                case "down":
                    player.stopDown = true;
                break;
                case "right":
                    player.stopRight = true;
                break;
                case "left":
                    player.stopLeft = true;
                break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.layer == 4)
        {
            switch(name)
		    {
			    case "up":
                    player.stopUp = false;
                break;
                case "down":
                    player.stopDown = false;
                break;
                case "right":
                    player.stopRight = false;
                break;
                case "left":
                    player.stopLeft = false;
                break;
            }
        }
    }
}

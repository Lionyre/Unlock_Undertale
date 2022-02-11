using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHazard : MonoBehaviour
{
    [SerializeField] private Player player = null;
    public bool electrique = false;
    private Animator direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 4 && other.gameObject.name == "Player" && (player.orange == true || electrique == true))
        {
            direction = other.gameObject.GetComponent<Animator>();
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("up"))
            {

            }
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("down"))
            {

            }
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("right"))
            {

            }
            if(direction.GetCurrentAnimatorStateInfo(0).IsName("left"))
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

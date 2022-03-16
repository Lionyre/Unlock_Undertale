using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit : MonoBehaviour
{
    [SerializeField] private Player player = null;
    public Sprite orange;
    public Sprite citron;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.orange == true)
            gameObject.GetComponent<Image> ().overrideSprite = orange;
        else
            gameObject.GetComponent<Image> ().overrideSprite = citron;
    }
}

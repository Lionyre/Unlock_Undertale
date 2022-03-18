using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    public GameObject terminado;
    public GameObject lemon;
    public GameObject effects;
    [SerializeField] private Player player = null;
    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.layer == 0 && player.stopAll == false)
        {
            terminado.SetActive(true);
            lemon.SetActive(false);
            effects.SetActive(false);
            player.stopAll = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private GameManagerSteph _gmSteph;

    [SerializeField] Sprite _croix, _triangle;

    [SerializeField] Stat _stat;

    enum Stat
    {
        Rond,
        Croix,
        Triangle
    }

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
        _gmSteph = GameObject.FindObjectOfType<GameManagerSteph>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == _player.gameObject.name)
        {
            if (_stat == Stat.Rond)
            {
                _gmSteph._counter++;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _croix;
                _stat = Stat.Croix;
            }
            else if (_stat == Stat.Croix)
            {
                _gmSteph._counter--;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _triangle;
                _stat = Stat.Triangle;
            }
        }

        // other.gameObject.GetComponent<SpriteRenderer>().sprite = _croix;

        // if(other.gameObject)

    }
}

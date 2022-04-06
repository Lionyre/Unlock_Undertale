using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    [SerializeField] private PlayerPMove _player;

    [SerializeField] private GameManagerSteph _gmSteph;

    [SerializeField] Sprite _croix;

    [SerializeField] Stat _stat;

    [SerializeField] Sprite[] _sprite;

    private int i = 0;

    public enum Stat
    {
        Rond,
        Croix,
        Triangle
    }

    private void Start()
    {
        _player = GameObject.FindObjectOfType<PlayerPMove>();
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
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite[0];
                _stat = Stat.Triangle;
            }
            else if (_stat == Stat.Triangle)
            {
                int newI = Random.Range(0, _sprite.Length);



                if (i != newI)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite[i];

                }

                if (i == newI)
                {
                    if (newI == _sprite.Length) // Lenght longueur du tableau;
                    {
                        i = newI - 1;
                    }
                    else
                    {
                        i = newI + 1;
                    }
                }
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite[i];


                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
            }
        }

        if (other.gameObject.name == _player.gameObject.name)
        {
            other.GetComponent<PlayerPMove>()._canMove = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == _player.gameObject.name)
        {
            collision.GetComponent<PlayerPMove>()._canMove = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForm : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private GameManagerSteph _gmSteph;

    [SerializeField] Sprite _croix;

    [SerializeField] Stat _stat;

    [SerializeField] Sprite[] _sprite;

    private int i = 0;

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
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite[0];
                _stat = Stat.Triangle;
            }
            else if (_stat == Stat.Triangle)
            {
                
                 i = Random.Range(0,_sprite.Length - 1);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _sprite[i];

                this.gameObject.GetComponent<SpriteRenderer>().color = new Vector4(Random.Range(0,255), Random.Range(0,255),Random.Range(0,255),255);

                

            }

        }

        // other.gameObject.GetComponent<SpriteRenderer>().sprite = _croix;

        // if(other.gameObject)

    }
}

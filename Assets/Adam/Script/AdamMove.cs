using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdamMove : MonoBehaviour
{
    [Header ("SerializeField")]

    [SerializeField] Transform _player = null;
    [SerializeField] Slider _clickCounter;

    //----------------------------------------------------//

    [Header("Game Stat")]

    public bool _isStarted = false;
    public bool _isEnded = false;
    public bool _enemyWin = false;

    //----------------------------------------------------//

    [Header("Statistique")]

    public float PlayerSpeed;
    public float clickPerSecond;
    public float _timer = 1;
    public float _maxValue = 0.6f;

    //----------------------------------------------------//

    private void Start()
    {
        _clickCounter.maxValue = 1;
        _clickCounter.value = .01f;
    }
    private void Update()
    {
        if(_isStarted == true)
        {
            _timer += Time.deltaTime;
            if(_clickCounter.value < 1) _clickCounter.value = Mathf.InverseLerp(0, 14, clickPerSecond / _timer);
        }

        SnailEndGame();
    }

    public void MovePlayer()
    {
        _player.position += new Vector3(_clickCounter.value / 10, 0, 0);

        if (_isStarted == true) clickPerSecond++;

        _isStarted = true;
    }

    public void SnailEndGame()
    {
        if(_clickCounter.value > _maxValue || _enemyWin == true)
        {
            Debug.Log("Game is losed");
            SceneManager.LoadScene(1);
        }

        if(_isEnded == true)
        {
            // Take Next Card
        }
    }
}

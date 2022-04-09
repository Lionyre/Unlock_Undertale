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
    public bool _canClick = false;

    //----------------------------------------------------//

    [Header("Statistique")]

    public float clickPerSecond, _timer = 1;
    public float _maxValue = 0.9f;
    public float _ratio = 10;

    //----------------------------------------------------//

    [Header("Start Game")]

    public Animator _supportAnimator = null;
    public Animator _snailAnimator = null;

    //----------------------------------------------------//

    [Header("End Game")]

    public GameObject _endLosePanel = null;
    public GameObject _endWinPanel = null;
    public EnterMachine _enterMachine = null;

    private void Awake()
    {
        _clickCounter.maxValue = 1;
        _clickCounter.value = .01f;
        _canClick = false;
        Time.timeScale = 1f;

        _enterMachine = GameObject.FindObjectOfType<EnterMachine>();
    }
    private void Update()
    {
        if(_isStarted == true)
        {
            _timer += Time.deltaTime;
            if(_clickCounter.value < 1) _clickCounter.value = Mathf.InverseLerp(0, 9, clickPerSecond / _timer);
        }

        SnailEndGame();

    }

    private void FixedUpdate()
    {
        _player.position += new Vector3(2 * _clickCounter.value / (10 / (_ratio / 10)), 0, 0);
    }

    public void MovePlayer()
    {
        if (_isStarted == true)
        {
            _snailAnimator.SetTrigger("Start");

            if (_canClick == true) { clickPerSecond++; _supportAnimator.speed = _clickCounter.value * 5; _snailAnimator.speed = _clickCounter.value; }
            if (_canClick == true && _clickCounter.value > _maxValue) _canClick = false;
        }
        else
        {
            _isStarted = true;
            StartCoroutine(StartGame());
        }
    }

    public void SnailEndGame()
    {
        if(_enemyWin == true && _isEnded == false)
        {
            _endLosePanel.SetActive(true);
            _canClick = false;
        }
        else if(_isEnded == true && _enemyWin == false)
        {
            _endWinPanel.SetActive(true);
            _canClick = false;
        }
    }

    IEnumerator StartGame()
    {
        _supportAnimator.SetTrigger("Start");
        yield return new WaitForSeconds(4f);
        _canClick = true;
    }
}

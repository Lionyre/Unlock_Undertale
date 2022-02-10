using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdamMove : MonoBehaviour
{
    [SerializeField] Transform _player = null;
    [SerializeField] Slider _clickCounter;
    public float PlayerSpeed;

    public float clickPerSecond;

    public float _timer;

    private void Start()
    {
        _clickCounter.maxValue = _clickCounter.maxValue * PlayerSpeed;
        _clickCounter.value = .1f;
    }
    private void Update()
    {
        _timer += Time.fixedDeltaTime;

        _clickCounter.value = clickPerSecond/ _timer;

        _player.position += new Vector3(_clickCounter.value / 10, 0, 0);
    }

    public void MovePlayer()
    {
        

        clickPerSecond += PlayerSpeed;

    }
}

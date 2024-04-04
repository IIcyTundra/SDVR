using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TimeController : MonoBehaviour
{
    private bool _timerActive;
    private float _currentTime;
    //public Text timerText;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        _currentTime = 0;
        _timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerActive)
        {
            _currentTime += Time.deltaTime;
        }

        timerText.text = _currentTime.ToString();
        //Debug.Log("Elapsed Time: " + _currentTime);

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString() + ":" + time.Milliseconds.ToString();
        //timerText.text = _currentTime.ToString("F2");

    }
}

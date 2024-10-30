using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class HandRecorderActivate : MonoBehaviour
{
    [SerializeField] private TMP_Text _textCounter;

    [SerializeField] private int _timer;
     private float _timerFrequency;
   


    public bool recordFrequencyStarted;

    private void Start()
    {
        _timerFrequency = _timer;
    }

    public void SetRecordStart(bool recordFrequency)
    {
        recordFrequencyStarted = recordFrequency;
    }

    private void Update()
    {
        StartTimer();
    }


    public void StartTimer()
    {
        if (recordFrequencyStarted)
        {
            if (_timerFrequency > 0)
            {
                _timerFrequency -= Time.deltaTime;
                _textCounter.text = $"{Mathf.CeilToInt(_timerFrequency)}";
            }
            else
            {
                recordFrequencyStarted=false;
                _timerFrequency = _timer;
                _textCounter.text = $"{Mathf.CeilToInt(_timerFrequency)}";
            }
        }
    }
}

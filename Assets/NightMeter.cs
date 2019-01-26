using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMeter : MonoBehaviour
{
    [SerializeField]
    private float _nightLength = 300f;
    [SerializeField]
    private List<HourMeter> _hourMeters;

    private HourMeter _currentHourMeter;

    private float _timePassed = 0f;
    private float _hourLength;
    private float _currentHourTime = 0f;
    private bool _nightInProgress = true;

    private void Start()
    {
        _currentHourMeter = _hourMeters[0];
        _hourLength = _nightLength / _hourMeters.Count;

        foreach (var meter in _hourMeters)
        {
            meter.SetProgress(0f);
        }
    }

    private void Update()
    {
        if (!_nightInProgress) return;

        _timePassed += Time.deltaTime;
        _currentHourTime += Time.deltaTime;

        if (_currentHourTime > _hourLength)
        {
            ChangeHour();
            return;
        }

        _currentHourMeter.SetProgress(_currentHourTime / _hourLength);
    }

    private void ChangeHour()
    {
        _currentHourTime = 0f;
        int currentHourMeterIndex = Mathf.FloorToInt((_timePassed / _nightLength) * _hourMeters.Count);

        if (currentHourMeterIndex >= _hourMeters.Count)
        {
            _nightInProgress = false;
            return;
        }

        _currentHourMeter = _hourMeters[currentHourMeterIndex];
    }
}
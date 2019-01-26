using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NightMeter : MonoBehaviour
{
    [SerializeField]
    private float _nightLength = 300f;
    [SerializeField]
    private List<HourMeter> _hourMeters;

    private HourMeter _currentHourMeter;
    private EnemySpawner _enemySpawner;

    private float _currentHourTime = 0f;
    private int _currentHourIndex = 0;

    private void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _enemySpawner.WaveComplete += ChangeHour;
        _enemySpawner.SpawnNextWave();

        _currentHourMeter = _hourMeters[0];

        foreach (var meter in _hourMeters)
        {
            meter.Progress = 0f;
        }

        TimePanel.Instance.Show("12:00 PM", _currentHourIndex + 1);
    }

    private void ChangeHour()
    {
        _currentHourIndex += 1;
        DOTween.To(() => _currentHourMeter.Progress, val => _currentHourMeter.Progress = val, 1f, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutCubic)
            .OnStart(() =>
            {
                TimePanel.Instance.Show($"{_currentHourIndex}:00 AM", _currentHourIndex + 1);
            })
            .OnComplete(() =>
            {
                if (_currentHourIndex >= _hourMeters.Count) return;

                _currentHourMeter = _hourMeters[_currentHourIndex];
                _enemySpawner.SpawnNextWave();
            });
    }
}
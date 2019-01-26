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
    }

    private void ChangeHour()
    {
        DOTween.To(() => _currentHourMeter.Progress, val => _currentHourMeter.Progress = val, 1f, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutCubic)
            .OnComplete(() =>
            {
                _currentHourIndex += 1;
                _currentHourMeter = _hourMeters[_currentHourIndex];

                _enemySpawner.SpawnNextWave();
            });
    }
}
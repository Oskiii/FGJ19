using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class NightMeter : MonoBehaviour
{
    [SerializeField]
    private GameObject _hourMarkerPrefab;

    [SerializeField]
    private float _nightLength = 300f;
    [SerializeField]
    private int _hourCount = 8;
    [SerializeField]
    private Slider _timeSlider;
    [SerializeField]
    private RectTransform _timeSliderBg;
    private int _currentHourIndex = 0;

    private EnemySpawner _enemySpawner;

    private void Start()
    {
        _enemySpawner = FindObjectOfType<EnemySpawner>();
        _enemySpawner.WaveComplete += ChangeHour;
        _enemySpawner.SpawnNextWave();

        FindObjectOfType<Player>().GetComponent<Health>().OnDie +=
            () => WinPanel.Instance.Show(_currentHourIndex * 60f);

        TimePanel.Instance.Show("12:00 PM", _currentHourIndex + 1);

        _timeSlider.value = 0f;
    }

    private void ChangeHour()
    {
        _currentHourIndex += 1;

        float goalValue = (float) _currentHourIndex / (float) _hourCount;
        _timeSlider.DOValue(goalValue, 1f)
            .SetDelay(1f)
            .SetEase(Ease.InOutCubic)
            .OnStart(() =>
            {
                if (_currentHourIndex < _hourCount)
                {
                    TimePanel.Instance.Show($"{_currentHourIndex}:00 AM", _currentHourIndex + 1);
                }
            })
            .OnComplete(() =>
            {
                if (_currentHourIndex >= _hourCount)
                {
                    WinPanel.Instance.Show(_currentHourIndex * 60f);
                }

                _enemySpawner.SpawnNextWave();
            });
    }
}
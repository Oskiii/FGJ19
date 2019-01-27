using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;
    [SerializeField]
    private GameObject _bg;

    [SerializeField]
    private Slider _sleepMeter;
    [SerializeField]
    private List<Image> _stars;
    [SerializeField]
    private TextMeshProUGUI _sleepTimeText;
    [SerializeField]
    private TextMeshProUGUI _dayText;

    public static WinPanel Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        foreach (var star in _stars)
        {
            star.transform.localScale = Vector2.zero;
        }
    }

    public void Show(float sleepMinutes)
    {
        _panel.SetActive(true);
        _bg.SetActive(true);

        _dayText.text = DifficultyManager.Instance.DayString + " night";

        DifficultyManager.Instance.Increase();

        float fullSleepMinutes = 8 * 60f;
        float percentage = sleepMinutes / fullSleepMinutes;

        _sleepMeter.DOValue(percentage, 3.5f)
            .SetEase(Ease.OutCirc)
            .OnUpdate(() =>
            {
                var time = TimeSpan.FromMinutes(sleepMinutes * _sleepMeter.value);
                _sleepTimeText.text = String.Format("{0:00}:{1:00} hours", (int) time.TotalHours, time.Minutes);

                if (_sleepMeter.value > 0.4f)
                {
                    UnlockStar(0);
                }

                if (_sleepMeter.value > 0.6f)
                {
                    UnlockStar(1);
                }

                if (_sleepMeter.value > 0.9f)
                {
                    UnlockStar(2);
                }
            })
            .OnComplete(() => BounceStars());
    }

    private void UnlockStar(int star)
    {
        _stars[star].transform.DOScale(Vector2.one, 0.4f)
            .SetEase(Ease.OutBack);
    }

    private void BounceStars()
    {
        foreach (var star in _stars)
        {
            star.transform.DOPunchScale(Vector2.one * 0.2f, 0.2f);
        }
    }

    public void NextNight()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
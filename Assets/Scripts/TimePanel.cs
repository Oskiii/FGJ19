using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeText;
    [SerializeField]
    private TextMeshProUGUI _waveText;
    [SerializeField]
    private TextMeshProUGUI _dayText;
    private CanvasGroup _canvasGroup;

    public static TimePanel Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show(string timeText, int wave)
    {
        _timeText.text = timeText;
        _waveText.text = $"Wave {wave}";
        _dayText.text = DifficultyManager.Instance.DayString + " night";

        Sequence seq = DOTween.Sequence();
        seq.Append(_canvasGroup.DOFade(1f, 0.05f));
        seq.AppendInterval(3f);
        seq.Append(_canvasGroup.DOFade(0f, 0.5f));
    }
}
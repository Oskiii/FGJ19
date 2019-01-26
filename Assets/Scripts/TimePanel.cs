using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeText;
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

    public void Show(string text)
    {
        _timeText.text = text;

        Sequence seq = DOTween.Sequence();
        seq.Append(_canvasGroup.DOFade(1f, 0.05f));
        seq.AppendInterval(3f);
        seq.Append(_canvasGroup.DOFade(0f, 0.5f));
    }
}
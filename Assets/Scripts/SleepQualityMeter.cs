using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SleepQualityMeter : MonoBehaviour
{
    [SerializeField]
    private float _maxQuality = 10f;
    private Slider _slider;
    private float _quality;

    private void Start()
    {
        _slider.maxValue = _maxQuality;
    }

    public void ReduceQuality(float amount)
    {
        _quality -= amount;
        _slider.value = _quality;
    }
}
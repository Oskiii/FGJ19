using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourMeter : MonoBehaviour
{
    private Slider _slider;
    private float _progress = 0f;
    public float Progress
    {
        get
        {
            return _progress;
        }
        set
        {
            _progress = value;
            _slider.value = value;
        }
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }
}
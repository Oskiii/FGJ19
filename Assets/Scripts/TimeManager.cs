using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TimeManager
{
    public static void Slowdown(float amount = 0.4f, float duration = 0.03f)
    {
        var goalScale = 1f - amount;

        var seq = DOTween.Sequence();
        seq.Append(DOTween.To(() => Time.timeScale, val => Time.timeScale = val, goalScale, duration)
            .OnUpdate(() => Debug.Log(Time.timeScale))
            .OnComplete(() =>
            {
                Time.timeScale = goalScale;
            }));

        seq.Append(DOTween.To(() => Time.timeScale, val => Time.timeScale = val, 1f, duration)
            .OnUpdate(() => Debug.Log(Time.timeScale))
            .OnComplete(() =>
            {
                Time.timeScale = 1f;
            }));
    }
}
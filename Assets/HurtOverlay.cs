using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HurtOverlay : MonoBehaviour
{
    [SerializeField]
    private Image _overlay;

    public void Hurt()
    {
        _overlay.DOFade(0.5f, 0.03f).OnComplete(() =>
        {
            _overlay.DOFade(0f, 0.4f);
        });
    }
}
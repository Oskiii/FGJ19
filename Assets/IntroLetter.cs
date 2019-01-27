using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class IntroLetter : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _shadow;
    [SerializeField]
    private SpriteRenderer _letter;
    [SerializeField]
    private SpriteRenderer _arrow;
    [SerializeField]
    private RectTransform _letterPanel;

    [SerializeField]
    private Sprite _letterOpenSprite;

    public event System.Action OnClosed;

    private bool _opened = false;
    private List<Tweener> _bounceTweens = new List<Tweener>();

    private void Start()
    {
        float bounceTime = 0.5f;

        var shadowGoalScale = _shadow.transform.localScale;
        shadowGoalScale *= 0.7f;

        _bounceTweens.Add(_shadow.transform.DOScale(shadowGoalScale, bounceTime)
            .SetLoops(-1, LoopType.Yoyo));

        _bounceTweens.Add(_letter.transform.DOMoveY(_letter.transform.position.y + 0.3f, bounceTime)
            .SetLoops(-1, LoopType.Yoyo));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_opened)
            OpenLetter();
    }

    private void OpenLetter()
    {
        _opened = true;
        _letter.sprite = _letterOpenSprite;

        foreach (var item in _bounceTweens)
        {
            item.Kill(true);
        }

        ShowText();
    }

    private void Update()
    {
        if (_opened && (Input.GetButtonDown("Submit") || Input.GetButtonDown("Fire1")))
        {
            StartPlay();
        }
    }

    private void ShowText()
    {
        AudioManager.Instance.Play("open letter");
        _letterPanel.gameObject.SetActive(true);

        _letterPanel.DOMoveY(-300f, 2f).From().SetEase(Ease.OutBack);
    }

    public void StartPlay()
    {
        _letterPanel.DOMoveY(-300f, 2f).SetEase(Ease.InBack).OnComplete(() =>
        {
            _letterPanel.gameObject.SetActive(false);
            Destroy(gameObject);

            OnClosed?.Invoke();
        });
    }
}
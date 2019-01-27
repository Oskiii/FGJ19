using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _hud;
    [SerializeField]
    private GameObject _letterPrefab;
    [SerializeField]
    private List<GameObject> _spawners;

    private void Awake()
    {
        foreach (var item in _spawners)
        {
            item.SetActive(false);
        }
    }

    private void Start()
    {
        if (DifficultyManager.Instance.Day != 0)
        {
            foreach (var item in _spawners)
            {
                item.SetActive(true);
            }
        }
        else
        {
            _hud.SetActive(false);

            var letterObj = Instantiate(_letterPrefab);
            var letter = letterObj.GetComponent<IntroLetter>();
            letter.OnClosed += StartPlay;
        }
    }

    private void StartPlay()
    {
        _hud.SetActive(true);

        foreach (var item in _spawners)
        {
            item.SetActive(true);
        }
    }
}
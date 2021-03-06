﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableFx : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onEnable;

    private void OnEnable()
    {
        _onEnable.Invoke();
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private IMover _movement;

    private void Start() {
        _movement = GetComponent<BasicMovement>();
    }

    private void Update() {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        _movement.Move(new Vector2(x,y));
    }
}

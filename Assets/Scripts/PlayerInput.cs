using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private IMover _movement;

    private void Start() {
        _movement = GetComponent<IMover>();
    }

    private void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        var moveDir = new Vector2(x, y).normalized;
        _movement.Move(moveDir);
    }
}
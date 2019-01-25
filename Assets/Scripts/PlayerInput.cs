using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _movement;

    private void Start() {
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update() {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        _movement.Move(new Vector2(x,y));
    }
}

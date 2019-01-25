using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSpriteToVelocity : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private Transform _sprite;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _sprite.up = _rb.velocity;
    }
}

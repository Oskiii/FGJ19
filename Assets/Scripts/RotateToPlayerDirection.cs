using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayerDirection : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Rigidbody2D _rbPlayer;
    [SerializeField]
    private Transform _sprite;
    [SerializeField]
    private float _predictionMultiplier = 0.15f;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _sprite.up = _rb.velocity + _rbPlayer.velocity * _predictionMultiplier;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMover
{
    private Rigidbody2D _rb;

    [SerializeField]
    private float _moveSpeed = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 dir)
    {
        _rb.velocity = (dir * _moveSpeed);
    }
}
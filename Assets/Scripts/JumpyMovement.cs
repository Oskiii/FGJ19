using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyMovement : MonoBehaviour, IMover
{
    private Rigidbody2D _rb;
    private float _timeSinceLastJump = 0f;
    private Vector2 _dir;
    private bool _jumping;

    [SerializeField]
    private float _moveSpeed = 10f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _jumping = false;
    }

    private void Update()
    {
        if(_timeSinceLastJump >= 2.0f)
        {
          _jumping = true;
          _timeSinceLastJump = 0.0f;
        }

        if(_timeSinceLastJump < 2.0f && _timeSinceLastJump > 1.0f)
        {
          _jumping = false;
        }

        if(_jumping) {
          Jump(_dir);
        }

        _timeSinceLastJump += Time.deltaTime;
    }

    public void Move(Vector2 dir)
    {
        if(!_jumping)
        {
          _dir = dir;
        }
    }

    private void Jump(Vector2 dir)
    {
        _rb.velocity = (dir * _moveSpeed);
    }
}

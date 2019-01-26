using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpyMovement : MonoBehaviour, IMover {
  private Rigidbody2D _rb;
  private float _timeSinceLastJump = 0f;
  private Vector2 _dir;
  private bool _jumping;

  [SerializeField]
  private float _moveSpeed = 10f;
  [SerializeField]
  private float _jumpTimer = 2f;

  private void Start () {
    _rb = GetComponent<Rigidbody2D> ();
    _jumping = false;
  }

  private void Update () {
    if (_timeSinceLastJump >= _jumpTimer) {
      _jumping = true;
      _timeSinceLastJump = 0.0f;
    }

    if (_timeSinceLastJump < _jumpTimer && _timeSinceLastJump > 1f && _jumping) {
      _jumping = false;
      _rb.velocity = Vector2.zero;
    }

    if (_jumping) {
      Jump (_dir);
    }

    _timeSinceLastJump += Time.deltaTime;
  }

  public void SetDirection (Vector2 dir) {
    if (!_jumping) {
      _dir = dir;
    }
  }

  private void Jump (Vector2 dir) {
    _rb.velocity = (dir * _moveSpeed);
  }
}
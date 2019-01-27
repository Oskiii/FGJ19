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
  private float _jumpWait = 2f;
  [SerializeField]
  private float _jumpTime = 1f;

  private void Start () {
    _rb = GetComponent<Rigidbody2D> ();
    _jumping = false;
  }

  private void Update () {
    if (_timeSinceLastJump >= _jumpWait) {
      _jumping = true;
      _timeSinceLastJump = 0.0f;
            FindObjectOfType<AudioManager>().Play("attack01");
            FindObjectOfType<AudioManager>().ChangePitch("attack01", Random.Range(0.85f, 1.15f));
        }

    if (_timeSinceLastJump < _jumpWait && _timeSinceLastJump > _jumpTime && _jumping) {
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
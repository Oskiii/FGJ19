using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate360 : MonoBehaviour {
  private Rigidbody2D _rb;
  [SerializeField]
  private Transform _sprite;
  private float _angle = 0f;

  private void Start () {
    _rb = GetComponent<Rigidbody2D> ();
  }

  private void Update () {
    _sprite.up = Quaternion.AngleAxis (_angle, new Vector3 (0, 0, 1)) * new Vector3 (1, 0, 0);
    _angle += 6;
  }
}
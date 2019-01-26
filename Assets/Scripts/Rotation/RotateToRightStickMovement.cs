using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToRightStickMovement : MonoBehaviour {
  private Camera _mainCam;

  private void Start () {
    _mainCam = Camera.main;
  }

  private void Update () {
    float x = Input.GetAxis ("HorizontalRightStick");
    float y = Input.GetAxis ("VerticalRightStick");
    Vector2 dir = new Vector2 (x, y);
    if (dir.sqrMagnitude > 0) {
      transform.up = new Vector2 (x, y);
    }
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour {
  private Camera _mainCam;
  private bool _usingController;

  private void Start () {
    _mainCam = Camera.main;
  }

  private void Update () {
    Vector3 screenPos = new Vector3 ();

    screenPos.x = Input.mousePosition.x;
    screenPos.y = Input.mousePosition.y;
    screenPos.z = -Camera.main.transform.position.z;
    Vector3 worldPos = Camera.main.ScreenToWorldPoint (screenPos);

    float controllerX = Input.GetAxis ("HorizontalRightStick");
    float controllerY = Input.GetAxis ("VerticalRightStick");

    if (controllerX > 0 || controllerY > 0) _usingController = true;

    if (_usingController) {
      Vector2 dir = new Vector2 (controllerX, controllerY);
      if (dir.sqrMagnitude > 0) {
        transform.up = dir;
      }
    } else {
      transform.up = worldPos - transform.position;
    }
  }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingAnimations : MonoBehaviour {
  private Animator _animator;
  private bool _usingController = false;

  private void Start () {
    _animator = GetComponent<Animator> ();
  }

  private void Update () {
    Vector3 screenPos = new Vector3 ();

    screenPos.x = Input.mousePosition.x;
    screenPos.y = Input.mousePosition.y;
    screenPos.z = -Camera.main.transform.position.z;
    Vector3 worldPos = Camera.main.ScreenToWorldPoint (screenPos);
    Vector3 vecToMouse = worldPos - transform.position;

    float controllerX = Input.GetAxis ("HorizontalRightStick");
    float controllerY = Input.GetAxis ("VerticalRightStick");

    if (controllerX > 0 || controllerY > 0) _usingController = true;
    if (_usingController) {
      Vector2 dir = new Vector2 (controllerX, controllerY);
      if (dir.sqrMagnitude > 0) {
        _animator.SetFloat ("FacingX", dir.x);
        _animator.SetFloat ("FacingY", dir.y);
      }
    } else {
      _animator.SetFloat ("FacingX", vecToMouse.x);
      _animator.SetFloat ("FacingY", vecToMouse.y);
    }

  }
}
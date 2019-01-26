using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToNearestDirection : MonoBehaviour {
  private Camera _mainCam;

  private void Start () {
    _mainCam = Camera.main;
  }

  private void Update () {
    Vector3 screenPos = new Vector3 ();

    screenPos.x = Input.mousePosition.x;
    screenPos.y = Input.mousePosition.y;
    screenPos.z = -Camera.main.transform.position.z;
    Vector3 worldPos = Camera.main.ScreenToWorldPoint (screenPos);
    Vector3 shootingDir = worldPos - transform.position;
    if (Mathf.Abs (shootingDir.x) > Mathf.Abs (shootingDir.y)) {
      shootingDir.y = 0;
    } else if (Mathf.Abs (shootingDir.x) < Mathf.Abs (shootingDir.y)) {
      shootingDir.x = 0;
    }
    transform.up = shootingDir;
  }
}
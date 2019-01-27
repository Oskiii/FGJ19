using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpiderMovement : MonoBehaviour, IMover {
  // Start is called before the first frame update
  [SerializeField]
  private float _descentHeight = 7f;
  void Start () {
    transform.DOMoveY (transform.position.y - _descentHeight, 2);
  }

  public void SetDirection (Vector2 dir) {
    return;
  }
}
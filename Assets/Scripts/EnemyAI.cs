using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
  private IMover _movement;
  private IGun _gun;
  private Vector2 _targetPos;

  void Start () {
    _movement = GetComponent<IMover>();
    _gun = GetComponentInChildren<IGun>();
  }

  void Update () {
    _targetPos = GameObject.FindGameObjectWithTag("Player").transform.position;
    var moveDir = new Vector2 (_targetPos.x - transform.position.x, _targetPos.y - transform.position.y).normalized;
    _movement.SetDirection (moveDir);

    var shouldShoot = true;
    _gun.SetShouldShoot(shouldShoot);
  }
}
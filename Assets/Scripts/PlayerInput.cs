using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
  private IMover _movement;
  private Player _player;

  private void Start () {
    _movement = GetComponent<IMover> ();
    _player = GetComponent<Player> ();
  }

  private void Update () {
    var x = Input.GetAxisRaw ("Horizontal");
    var y = Input.GetAxisRaw ("Vertical");
    var moveDir = new Vector2 (x, y).normalized;
    _movement.SetDirection (moveDir);

    var shouldShoot = Input.GetMouseButton (0);
    _player.CurrentGun.GetComponent<IGun> ().SetShouldShoot (shouldShoot);
  }
}
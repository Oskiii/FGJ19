using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  [SerializeField]
  private Transform _sprite;

  public Gun CurrentGun;

  void Start () {
    CurrentGun = GetComponentInChildren<Gun> ();
  }

  public void SetGun (Gun gun) {
    Destroy (GetComponentInChildren<Gun> ().gameObject);
    GameObject newGun = Instantiate (gun.gameObject, _sprite);
    newGun.transform.position = _sprite.transform.position;
    CurrentGun = newGun.GetComponent<Gun> ();
  }
}
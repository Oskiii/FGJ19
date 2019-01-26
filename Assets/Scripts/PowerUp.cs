using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

  [SerializeField]
  private Gun _newGun;

  private void OnTriggerEnter2D (Collider2D other) {
    bool isPlayer = other.transform.root.gameObject.tag == "Player";
    if (!isPlayer) return;

    other.transform.root.gameObject.GetComponent<Player> ().SetGun (_newGun);
    Destroy (gameObject);
  }
}
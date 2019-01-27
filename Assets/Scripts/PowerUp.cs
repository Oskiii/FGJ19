using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PowerUp : MonoBehaviour {

  [SerializeField]
  private Gun _newGun;
  [SerializeField]
  private Gun _basicGun;
  [SerializeField]
  private float _lifeTime = 5f;
  [SerializeField]
  private float _activeTime = 10f;
  private Rigidbody2D _rb;

  private void Start () {
    _rb = GetComponent<Rigidbody2D> ();
    Destroy (gameObject, _lifeTime);
    var spawnLocation = new Vector2 (Random.Range (-7, 13), Random.Range (-7, 8));
    transform.DOMove (spawnLocation, spawnLocation.magnitude);
  }

  private void OnTriggerEnter2D (Collider2D other) {
    bool isPlayer = other.transform.root.gameObject.tag == "Player";
    if (!isPlayer) return;

    GameObject player = other.transform.root.gameObject;

    player.GetComponent<Player> ().SetGun (_newGun);
    Destroy (gameObject);

    player.GetComponent<Player> ().StartCoroutine (ChangeBackToBasicGun (_activeTime, player));
  }

  IEnumerator ChangeBackToBasicGun (float time, GameObject player) {
    yield return new WaitForSecondsRealtime (time);
    player.GetComponent<Player> ().SetGun (_basicGun);
  }
}
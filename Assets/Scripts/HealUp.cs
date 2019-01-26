using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HealUp : MonoBehaviour {
  [SerializeField]
  private int _healAmount;

  private float _lifeTime = 5f;
  private Rigidbody2D _rb;

  private void Start () {
    _rb = GetComponent<Rigidbody2D> ();
    Destroy (gameObject, _lifeTime);
    var spawnLocation = new Vector2 (Random.Range (-7, 13), Random.Range (-7, 8));
    transform.DOMove (spawnLocation, spawnLocation.magnitude);
  }

  private void OnCollisionEnter2D (Collision2D other) {
    bool isPlayer = other.transform.root.gameObject.tag == "Player";
    if (!isPlayer) return;

    other.gameObject.GetComponent<Health> ().Heal (_healAmount);
    Destroy (gameObject);
  }
}
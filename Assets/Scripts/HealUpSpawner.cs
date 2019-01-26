using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUpSpawner : MonoBehaviour {
  [SerializeField]
  private Transform _healUp;

  [SerializeField]
  private float spawnWait = 10f;

  void Start () {
    StartCoroutine (SpawnHealUps ());
  }

  IEnumerator SpawnHealUps () {
    yield return new WaitForSeconds (spawnWait);
    while (true) {
      Quaternion spawnRotation = Quaternion.identity;
      Instantiate (_healUp.gameObject, transform.position, spawnRotation);
      yield return new WaitForSeconds (spawnWait);
    }
  }
}
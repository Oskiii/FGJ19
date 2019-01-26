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
      Vector3 spawnPosition = new Vector3 (Random.Range (-10, 14), Random.Range (-8, 8), 0);
      Quaternion spawnRotation = Quaternion.identity;
      Instantiate (_healUp.gameObject, spawnPosition, spawnRotation);
      yield return new WaitForSeconds (spawnWait);
    }
  }
}
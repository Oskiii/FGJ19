using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {
  [SerializeField]
  private List<Transform> _powerUps;

  [SerializeField]
  private float spawnWait = 25f;

  void Start () {
    StartCoroutine (SpawnPowerUps ());
  }

  IEnumerator SpawnPowerUps () {
    yield return new WaitForSeconds (spawnWait);
    while (true) {
      Quaternion spawnRotation = Quaternion.identity;
      Transform powerUp = _powerUps[Random.Range (0, _powerUps.Count)];
      Instantiate (powerUp.gameObject, transform.position, spawnRotation);
      yield return new WaitForSeconds (spawnWait);
    }
  }
}
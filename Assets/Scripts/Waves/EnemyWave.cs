using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemyWave", menuName = "EnemyWave", order = 0)]
public class EnemyWave : ScriptableObject {
  [SerializeField]
  private float DelayBefore;
  [SerializeField]
  private List<EnemySpawnAmounts> EnemyAmounts;
  [SerializeField]
  private float DelayAfter;

  [System.Serializable]
  private class EnemySpawnAmounts {
    public GameObject Enemy;
    public int Amount;
  }

  public IEnumerator Spawn (List<Transform> spawnPoints, List<Transform> spiderSpawnPoints, Action<GameObject> onSpawn) {
    yield return new WaitForSeconds (DelayBefore);

    foreach (var e in EnemyAmounts) {
      for (int i = 0; i < e.Amount; i++) {
        Transform spawnPos;
        Vector3 randomVec;

        if (e.Enemy.GetComponent<SpiderMovement> () == null) {
          spawnPos = spawnPoints[UnityEngine.Random.Range (0, spawnPoints.Count)];
          randomVec = new Vector3 (UnityEngine.Random.Range (-2, 2), UnityEngine.Random.Range (-2, 2), 0);
        } else {
          spawnPos = spiderSpawnPoints[UnityEngine.Random.Range (0, spiderSpawnPoints.Count)];
          randomVec = new Vector3 (UnityEngine.Random.Range (-2, 2), 0, 0);
        }

        var enemy = Instantiate (e.Enemy, spawnPos.position + randomVec, Quaternion.identity);
        onSpawn (enemy);
      }
    }

    yield return new WaitForSeconds (DelayAfter);
  }
}
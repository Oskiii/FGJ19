using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoints;

    [SerializeField]
    private List<EnemyWave> _waves;

    private List<GameObject> _spawnedEnemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        foreach (var wave in _waves)
        {
            var spawnPos = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            yield return wave.Spawn(spawnPos, enemy =>
            {
                _spawnedEnemies.Add(enemy);
                enemy.GetComponent<Health>().OnDie += () => HandleEnemyDeath(enemy);
            });
        }
    }

    private void HandleEnemyDeath(GameObject enemy)
    {
        _spawnedEnemies.Remove(enemy);
        Destroy(enemy);

        CheckWin();
    }

    private void CheckWin()
    {
        if (_spawnedEnemies.Count == 0)
        {
            print("WINNER WINNER");
        }
    }
}
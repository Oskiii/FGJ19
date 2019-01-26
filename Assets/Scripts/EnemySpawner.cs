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

    private int _currentWaveIndex = 0;

    public event System.Action WaveComplete;

    public void SpawnNextWave()
    {
        StartCoroutine(SpawnWave(_currentWaveIndex));
        _currentWaveIndex += 1;
    }

    private IEnumerator SpawnWave(int waveIndex)
    {
        var wave = _waves[waveIndex];

        var spawnPos = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        yield return wave.Spawn(spawnPos, enemy =>
        {
            _spawnedEnemies.Add(enemy);
            enemy.GetComponent<Health>().OnDie += () => HandleEnemyDeath(enemy);
        });
    }

    private void HandleEnemyDeath(GameObject enemy)
    {
        _spawnedEnemies.Remove(enemy);
        Destroy(enemy);

        CheckWaveDone();
    }

    private void CheckWaveDone()
    {
        if (_spawnedEnemies.Count == 0)
        {
            WaveComplete?.Invoke();
        }
    }

    private void CheckWin()
    {
        if (_spawnedEnemies.Count == 0)
        {
            print("WINNER WINNER");
        }
    }
}
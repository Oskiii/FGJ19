using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _spawnPoints;

    [SerializeField]
    private List<EnemyWave> _waves;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        foreach (var wave in _waves)
        {
            var spawnPos = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            yield return wave.Spawn(spawnPos);
        }
    }
}
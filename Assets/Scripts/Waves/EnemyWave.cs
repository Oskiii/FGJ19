using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWave", menuName = "EnemyWave", order = 0)]
public class EnemyWave : ScriptableObject
{
    [SerializeField]
    private float DelayBefore;
    [SerializeField]
    private List<EnemySpawnAmounts> EnemyAmounts;
    [SerializeField]
    private float DelayAfter;

    [System.Serializable]
    private class EnemySpawnAmounts
    {
        public GameObject Enemy;
        public int Amount;
    }

    public IEnumerator Spawn(Transform spawnPoint)
    {
        yield return new WaitForSeconds(DelayBefore);

        foreach (var e in EnemyAmounts)
        {
            for (int i = 0; i < e.Amount; i++)
            {
                var enemy = Instantiate(e.Enemy, spawnPoint.position, Quaternion.identity);
            }
        }

        yield return new WaitForSeconds(DelayAfter);
    }
}
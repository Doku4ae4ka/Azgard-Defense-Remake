using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWave : IWave
{
    public IEnumerator SpawnEnemies(GameObject enemyPrefab, Transform spawnPoint, float delay, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject enemy = GameObject.Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
    }
}
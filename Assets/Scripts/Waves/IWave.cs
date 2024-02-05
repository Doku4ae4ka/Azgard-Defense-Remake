using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWave
{
    IEnumerator SpawnEnemies(GameObject enemyPrefab, Transform spawnPoint, float delay, int count);
}

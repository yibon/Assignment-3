using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave
{
    public string waveId { get; }
    public string enemyId { get; }

    public float spawnDelay { get; }
    public string enemyCount { get; }
    public string spawnPoint { get; }
    public string nextWaveId { get; }

    public EnemyWave (string waveId, string enemyId, float spawnDelay, string enemyCount, string spawnPoint, string nextWaveId)    {
        this.waveId = waveId;
        this.enemyId = enemyId;
        this.spawnDelay = spawnDelay;
        this.enemyCount = enemyCount;
        this.spawnPoint = spawnPoint;
        this.nextWaveId = nextWaveId;
    }
}

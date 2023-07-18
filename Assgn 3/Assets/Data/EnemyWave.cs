using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave
{
    //public string enemyId { get; }
    //public string enemyName { get; }

    //public float enemyHeath { get; }
    //public float enemyAttack { get; }
    //public float enemySpeed { get; }

    //public Enemy(string enemyId, string enemyName, float enemyHeath, float enemyAttack, float enemySpeed)
    //{
    //    this.enemyId = enemyId;
    //    this.enemyName = enemyName;
    //    this.enemyHeath = enemyHeath;
    //    this.enemyAttack = enemyAttack;
    //    this.enemySpeed = enemySpeed;
    //}

    public string waveId;
    public string enemyId;

    public float spawnDelay;
    public int enemyCount;
    public int spawnPoint;
}

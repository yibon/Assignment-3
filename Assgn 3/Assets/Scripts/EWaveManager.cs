// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: EWaveManager.cs
// Author: Yvonne Lim

using System;
using System.Linq;
using UnityEngine;

public class EWaveManager : MonoBehaviour
{
	private int enemiesSpawned;
	private string currEWave;
    private float timer;

	private EnemyWave _eWave;
    public GameObject enemyPrefab;

    private string[] splitEnemyId;
    private string[] splitEnemyCount;
    private int[] splitEnemyCountint;
    private string[] splitEnemySpawnPt;

    private void Start()
    {
        currEWave = "4001";
        SpawnEnemy();

    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (_eWave.spawnDelay != -1)
        {
            if (timer > _eWave.spawnDelay)
            {
                timer = 0;
                currEWave = _eWave.nextWaveId;
                SpawnEnemy();
            }
        }

        else
        {
            //Debug.Log("No more enemies!");
        }
    }

    private void SpawnEnemy()
    {
        //    set initial wave id-_eWave = getwavebyid(currwave);
        _eWave = Game.GetEWaveByRefId(currEWave);
        SplitString();

        for (int i = 0; i < splitEnemyId.Count(); i++)
        {
            for (int j = 0; j < splitEnemyCountint[i]; j++)
            {
                Debug.Log(splitEnemyId[i]);
                GameObject enemyObj = Instantiate(enemyPrefab, GetSpawnPointPos(splitEnemySpawnPt[i]), Quaternion.identity) as GameObject;
                enemyObj.GetComponent<EnemyScript>().currEnemyId = splitEnemyId[i];
            }
        }
    }


    private void SplitString()
    {
        splitEnemyId = _eWave.enemyId.Split("@");

        splitEnemyCount = _eWave.enemyCount.Split("@");
        splitEnemyCountint = Array.ConvertAll(splitEnemyCount, int.Parse);

        splitEnemySpawnPt = _eWave.spawnPoint.Split("@");
    }

    private Vector3 GetSpawnPointPos(string currSpawnPoint)
    {
        Vector3 spawnPoint = new Vector3(0,0);

        GameObject spawnPtObj = GameObject.Find("Spawn Points");

        switch (currSpawnPoint)
        {
            case "1":
                spawnPoint = spawnPtObj.transform.GetChild(0).position;
                break;            
            
            case "2":
                spawnPoint = spawnPtObj.transform.GetChild(1).position;
                break;            
            
            case "3":
                spawnPoint = spawnPtObj.transform.GetChild(2).position;
                break;            
            
            case "4":
                spawnPoint = spawnPtObj.transform.GetChild(3).position;
                break;
        }

        return spawnPoint;
    }
}

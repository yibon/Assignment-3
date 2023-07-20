
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

    public void OnDataLoadEWave()
    {
        currEWave = "4001";
        SpawnEnemy();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (_eWave.spawnDelay != -1)
        {
            if (timer > _eWave.spawnDelay * 0.5f)
            {
                timer = 0;
                currEWave = _eWave.nextWaveId;
                SpawnEnemy();
            }
        }

        else
        {
            Debug.Log("No more enemies!");
        }


     
        //	// resets the killed for boolean, try not to use for analytics
        //	enemiesKilled = 0;

        //	if spawnDelay is not -1
        //	{	
        //		if (timer > _eWave.spawnDelay)
        //			isTiming = false;
        //			currwave = nextrefid;
        //			spawnEnemy();
        //}


        //    else
        //{
        //    isTiming = false;
        //    debug.log("no more enemies!")

        //    }
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

        //for (int i = 0; i < splitEnemyId.Count(); i++)
        //{
        //    Debug.Log("Ids: " + splitEnemyId[i]);
        //    Debug.Log("Count: " + splitEnemyCountint[i]);
        //    Debug.Log("SpawnPts: " + splitEnemySpawnPt[i]);
        //}
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

    //vector3 getspawnpointpositions(string currspawnpoint);
    //{
    //    get the spawn point objects from the game

    //    get their  transform components,
    //    spawn1position = transform.position;
    //    spawn2position = transform.position;
    //    ...

    //	switch (currspawnpoint)

    //    case 1:
    //        spawnpoint = spawn1pos;
    //        break

    //    ...

    //	return spawnpoint
    //}

}

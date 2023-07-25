// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: DataLoader.cs
// Author: Yvonne Lim

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLoader : MonoBehaviour
{

    int dataIsLoaded;

    private void Start()
    {
        dataIsLoaded = 0;

        DataManager dataManager = GetComponent<DataManager>();

        dataManager.LoadRefDialogueData(onDataLoad);
        dataManager.LoadRefCharacterData(onDataLoad);
        dataManager.LoadRefEnemyData(onDataLoad);
        dataManager.LoadRefEWaveData(onDataLoad);
    }


    private void Update()
    {
        if (dataIsLoaded == 4)
        {
            SceneLoader.LoadScene(SceneLoader.Scenes.Cutscene1);
        }
    }

    private void onDataLoad()
    {
        ++dataIsLoaded;
    }
}

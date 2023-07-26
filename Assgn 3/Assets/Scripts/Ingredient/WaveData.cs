// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: WaveData.cs
// Author: Stella Tan


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveData
{
    public string stageId;
    public string ingredientWaveId;
    public string IngredientId;     // need split
    public string spawnDelay;       
    public string ingredientCount;  // need split
    public string spawnPositionMin;
    public string spawnPositionMax;
    public string nextIngredientWaveId;

    public string[] ingredientList;
    public int[] ingredientCountList;
    public Vector3 minPosition, maxPosition;
    
    public void SetIngredientLists(string ingredientId){
        this.ingredientList = ingredientId.Split('@');
    }

    public void SetIngredientCount(string ingredientCount)
    {
        // Split the ingredientCount string using '@' as the delimiter
        string[] countStrings = ingredientCount.Split('@');

        // Initialize the ingredientCountList as an array of integers
        ingredientCountList = new int[countStrings.Length];

        // Convert each element to an integer and store it in the ingredientCountList
        for (int i = 0; i < countStrings.Length; i++)
        {
            if (int.TryParse(countStrings[i], out int count))
            {
                ingredientCountList[i] = count;
            }
            else
            {
            }
        }
    }

    public void SetIngredientPosition(string spawnPositionMin, string spawnPositionMax)
    {
        string[] minPos = spawnPositionMin.Split(',');
        string[] maxPos = spawnPositionMax.Split(',');

        // Ensure that minPos and maxPos have at least 3 elements (x, y, and z positions)
        if (minPos.Length >= 3 && maxPos.Length >= 3)
        {
            // Parse individual elements to integers
            if (int.TryParse(minPos[0], out int minX) &&
                int.TryParse(minPos[1], out int minY) &&
                int.TryParse(minPos[2], out int minZ) &&
                int.TryParse(maxPos[0], out int maxX) &&
                int.TryParse(maxPos[1], out int maxY) &&
                int.TryParse(maxPos[2], out int maxZ))
            {
                // Create Vector3 instances using the parsed integer values
                minPosition = new Vector3(minX, minY, minZ);
                maxPosition = new Vector3(maxX, maxY, maxZ);
            }
            else
            {
                // Handle parsing failure if needed
                Debug.LogError("Failed to convert to integers.");
            }
        }
        else
        {
            // Handle if minPos or maxPos does not have enough elements
            Debug.LogError("Invalid input for spawnPositionMin or spawnPositionMax.");
        }
    }

}
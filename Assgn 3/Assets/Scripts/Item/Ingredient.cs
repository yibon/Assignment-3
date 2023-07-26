// UXG2520 & UXG2165 Assignment 3
// Team Name: Lavon
// File Name: Ingredient.cs
// Author: Stella Tan


using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to read the json file for ingredients.json
 * And return it as a type of IngredientList which is in another cs file
*/
public class Ingredient : MonoBehaviour
{
    public IngredientList ingredientList;
    [SerializeField] public TextAsset jsonTextAsset;
    // Start is called before the first frame update
    void Awake()
    {
        // string json_ingredient =   "Assets/Data/JSON/ingredients.json";
        
        if (jsonTextAsset != null)
        {
            string jsonData = jsonTextAsset.text;

            // Deserialize the JSON data into C# objects
            ingredientList = JsonUtility.FromJson<IngredientList>(jsonData);
        }
        else
        {
            Debug.LogError("JSON file not found: " + jsonTextAsset);
        }
    }
}
